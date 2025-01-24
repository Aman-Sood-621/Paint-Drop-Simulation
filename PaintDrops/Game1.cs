using DrawingLib.Graphics;
using DrawingLibrary.Graphics;
using DrawingLibrary.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PaintDropSimulation;
using PatternGenerationLib;
using ShapeLibrary;
using System;

namespace PaintDrops;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Screen _screen;
    private SpritesRenderer _spritesRenderer;
    private ShapesRenderer _renderer;
    private ISurface _surface;
    private Random r = new Random();
    private bool _generatorPhyllo = false;
    private bool _generatorClover = false;
    private bool _generatorState = false;
    private IPatternGenerator _patternPhylloGenerator;
    private IPatternGenerator _patternCloverGenerator;
    private SpriteFont _font;
    private Vector2 TextPositionGA = new Vector2(0, 0);
    private Vector2 TextPositionSF = new Vector2(0, 27);
    private Vector2 TextPositionPattern = new Vector2(0,450);
    private string _text = "Phyllotaxis";

    public Game1()
    {
        this.Window.AllowUserResizing = true;
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        RenderTarget2D renderTarget = new(GraphicsDevice, 640, 480);
        _surface = PaintDropSimulationFactory.CreateSurface(renderTarget.Width, renderTarget.Height);
        _patternPhylloGenerator = PatternFactory.CreatePhyllotaxis();
        _patternCloverGenerator = PatternFactory.CreateClover();
        _surface.PatternGeneration += _patternPhylloGenerator.CalculatePatternPoint;
        _screen = new(renderTarget);
        _spritesRenderer = new(GraphicsDevice);
        _renderer = new(GraphicsDevice);

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        _font = Content.Load<SpriteFont>("File");
    }

    protected override void Update(GameTime gameTime)
    {
        if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        CustomMouse.Instance.Update();
        CustomKeyboard.Instance.Update();

        if (CustomMouse.Instance.IsLeftButtonClicked())
        {
            Vector2? vect = CustomMouse.Instance.GetScreenPosition(_screen);

            if (vect != null)
            {
                Colour color = new Colour(r.Next(0, 256), r.Next(0, 256), r.Next(0, 256));
                ICircle Circle = (ShapesFactory.CreateCircle((float)10, new Vector(vect.Value.X, vect.Value.Y), color));
                IPaintDrop drop = PaintDropSimulationFactory.CreatePaintDrop(Circle);
                _surface.AddPaintDrop(drop);
            }
        }
        else if (CustomMouse.Instance.IsRightButtonClicked())
        {
            _surface.Drops.Clear();
            _patternPhylloGenerator.reset();
        }

        if (CustomKeyboard.Instance.IsKeyClicked(Keys.M))
        {
            if (!_generatorState)
            {
                _generatorPhyllo = true;
            }
            else
            {
                _generatorClover = true;
            }
        }
        else if (CustomKeyboard.Instance.IsKeyClicked(Keys.E))
        {
            if (!_generatorState)
            {
                _generatorPhyllo = false;
            }
            else
            {
                _generatorClover = false;
            }
        }
        else if (CustomKeyboard.Instance.IsKeyClicked(Keys.P))
        {
            if (!_generatorClover && !_generatorPhyllo)
            {
                if (!_generatorState)
                {
                    _surface.PatternGeneration -= _patternPhylloGenerator.CalculatePatternPoint;
                    _surface.PatternGeneration += _patternCloverGenerator.CalculatePatternPoint;
                    _generatorState = true;
                    _text = "Clover";
                }
                else
                {
                    _surface.PatternGeneration -= _patternCloverGenerator.CalculatePatternPoint;
                    _surface.PatternGeneration += _patternPhylloGenerator.CalculatePatternPoint;
                    _generatorState = false;
                    _text = "Phyllotaxis";
                }
            }
        }



        if (_generatorPhyllo)
        {
            if (CustomKeyboard.Instance.IsKeyClicked(Keys.Up))
            {
                _patternPhylloGenerator.IncrementGA();
            }
            else if (CustomKeyboard.Instance.IsKeyClicked(Keys.Down))
            {
                _patternPhylloGenerator.DecreaseGA();
            }
            else if (CustomKeyboard.Instance.IsKeyClicked(Keys.Left))
            {
                _patternPhylloGenerator.IncrementSF();
            }
            else if (CustomKeyboard.Instance.IsKeyClicked(Keys.Right))
            {
                _patternPhylloGenerator.DecreaseSF();
            }
        }


        if (_generatorPhyllo || _generatorClover)
        {
            Colour color = new Colour(r.Next(0, 256), r.Next(0, 256), r.Next(0, 256));
            _surface.GeneratePaintDropPattern(10,color);
        }

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        // TODO: Add your drawing code here
        _screen.Set();
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _renderer.Begin();
        foreach (IPaintDrop r in _surface.Drops)
        {
            _renderer.DrawShape(r.Circle);
        }
        _renderer.End();
        _spriteBatch.Begin();
        _spriteBatch.DrawString(_font, "Current Active Pattern: " + _text, TextPositionPattern, Color.Black);

        if (_generatorPhyllo && !_generatorClover)
        {
            _spriteBatch.DrawString(_font, "Golden Angle: " + _patternPhylloGenerator.ReturnGoldenAngle(), TextPositionGA, Color.Black);
            _spriteBatch.DrawString(_font, "Scaling Factor: " + _patternPhylloGenerator.ReturnScalingFactor(), TextPositionSF, Color.Black);
        }
        _spriteBatch.End();

        _screen.UnSet();
        _screen.Present(_spritesRenderer);
        base.Draw(gameTime);
    }
}
