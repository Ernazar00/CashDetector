# CashDetector

A sophisticated **Computer Vision Cash Detection and Recognition System** built in C# that uses advanced image processing algorithms to detect, analyze, and identify different denominations of currency (both banknotes and coins) from digital images.

## 🎯 Project Overview

**CashDetector** is a Windows desktop application that combines multiple computer vision techniques to automatically detect and recognize cash in digital images. The system can distinguish between different denominations of banknotes and coins, calculate total amounts, and provide visual feedback through image processing overlays.

### Key Features

- **🔍 Automatic Cash Detection**: Detects multiple cash objects in a single image
- **💰 Multi-Currency Support**: Recognizes various denominations (0.01, 0.1, 1, 2, 5, 10, 20, 50, 100, 200, 500)
- **🪙 Coin vs Banknote Classification**: Automatically distinguishes between circular coins and rectangular banknotes
- **📊 Statistical Analysis**: Performs color histogram analysis and statistical matching
- **🎨 Visual Processing Pipeline**: Real-time image processing with visual feedback
- **💹 Sum Calculation**: Automatically calculates total monetary value
- **🖼️ Interactive GUI**: User-friendly Windows Forms interface

## 🏗️ System Architecture

### Core Components

#### Image Processing Pipeline
1. **Binary Conversion** ([`BinaryConvertor`](CashDetector/Helpers/BinaryConvertor.cs))
   - Adaptive thresholding using average K-means
   - Bradley threshold algorithm
   - Grayscale conversion

2. **Morphological Operations** ([`Morphology`](CashDetector/Helpers/Morphology.cs))
   - Dilation and Erosion
   - Opening and Closing operations
   - Multiple structural element masks

3. **Object Detection** ([`Detector`](CashDetector/Helpers/Detector.cs))
   - Connected component analysis (ABC algorithm)
   - Edge detection
   - Distance transform

4. **Convolution Processing** ([`Svertka`](CashDetector/Helpers/Svertka.cs))
   - Mean filtering for noise reduction
   - Custom kernel convolutions

#### Recognition System
1. **Feature Extraction** ([`MyImageObject`](CashDetector/MyImageObject.cs))
   - Geometric properties (area, perimeter, centroid)
   - Color statistics and histograms
   - Shape analysis (circularity detection)

2. **Statistical Analysis** ([`Statistic`](CashDetector/Helpers/Statistic.cs))
   - RGB channel analysis
   - Color histograms
   - Average and dominant color extraction

3. **Pattern Matching** ([`Error`](CashDetector/Error.cs))
   - Multi-dimensional error calculation
   - Template matching with reference images
   - Best-fit denomination selection

### Technology Stack

- **Language**: C# (.NET Framework)
- **UI Framework**: Windows Forms
- **Image Processing**: System.Drawing
- **Platform**: Windows Desktop
- **Architecture**: Modular design with separation of concerns

## 🚀 Getting Started

### Prerequisites

- Windows 10/11
- .NET Framework 4.7.2 or higher
- Visual Studio 2019+ (for development)

### Installation

1. **Clone the repository**:
   ```bash
   git clone <repository-url>
   cd CashDetector
   ```

2. **Open the solution**:
   ```bash
   # Open in Visual Studio
   start CashDetector.sln
   ```

3. **Build and Run**:
   - Build Solution (Ctrl+Shift+B)
   - Start Debugging (F5)

### Quick Start

1. **Launch the application**
2. **Load an image**: Click "Open Image" and select a photo containing cash
3. **Process**: The system will automatically:
   - Convert to binary
   - Apply morphological operations
   - Detect individual cash objects
   - Classify as coins or banknotes
   - Match against reference templates
   - Display results with visual overlays
4. **View Results**: Check the output panel for detected denominations and total sum

## 📁 Project Structure

```
CashDetector/
├── CashDetector/
│   ├── Helpers/                    # Image processing utilities
│   │   ├── BinaryConvertor.cs      # Thresholding and binary conversion
│   │   ├── Detector.cs             # Object detection algorithms
│   │   ├── Grayworld.cs            # Grayscale processing
│   │   ├── Morphology.cs           # Morphological operations
│   │   ├── Statistic.cs            # Statistical analysis
│   │   └── Svertka.cs              # Convolution operations
│   ├── Properties/                 # Application properties
│   ├── SourceImages/               # Reference currency images
│   ├── MainWindow.cs               # Main UI logic
│   ├── MainWindow.Designer.cs      # Auto-generated UI code
│   ├── MyImageObject.cs            # Image object representation
│   ├── MyPixel.cs                  # Pixel-level operations
│   ├── Error.cs                    # Error/similarity calculation
│   ├── YIQ.cs                      # YIQ color space conversion
│   ├── Bit.cs                      # Binary operations
│   └── Program.cs                  # Application entry point
└── README.md                       # This file
```

## 🔬 Algorithm Details

### Detection Pipeline

1. **Preprocessing**:
   - Adaptive binary conversion using K-means clustering
   - Noise reduction with mean filtering
   - Morphological operations for object separation

2. **Object Detection**:
   - Connected component labeling (ABC algorithm)
   - Size filtering to remove noise
   - Boundary detection

3. **Feature Extraction**:
   - Geometric properties (area, perimeter, centroid)
   - Color statistics (RGB histograms, averages)
   - Shape analysis (circularity for coin detection)

4. **Classification**:
   - Shape-based classification (circular vs rectangular)
   - Template matching with reference images
   - Multi-dimensional error minimization

### Recognition Algorithm

```csharp
// Simplified recognition flow
foreach (detectedObject in objects) {
    // Extract features
    features = ExtractFeatures(detectedObject);
    
    // Determine if coin or banknote
    isCircular = AnalyzeCircularity(features);
    
    // Match against appropriate templates
    templates = isCircular ? coinTemplates : banknoteTemplates;
    bestMatch = FindBestMatch(features, templates);
    
    // Calculate confidence and assign denomination
    denomination = bestMatch.denomination;
    totalSum += denomination;
}
```

## 🎨 User Interface

The application features an intuitive Windows Forms interface with:

- **Image Display Panels**: Original and processed image views
- **Processing Controls**: Various algorithms and parameters
- **Results Panel**: Detected denominations and calculations
- **Real-time Feedback**: Visual overlays showing detected objects

## 🧪 Testing

The system includes test images in the [`SourceImages`](CashDetector/SourceImages/) directory with various currency denominations for validation and reference matching.

## 🔧 Configuration

- **Morphological Masks**: Configurable structural elements (3x3, 7x7 circular)
- **Detection Thresholds**: Adjustable sensitivity parameters
- **Size Filters**: Minimum object size requirements
- **Color Analysis**: RGB channel weighting

## 🚀 Future Enhancements

- [ ] **Deep Learning Integration**: CNN-based recognition
- [ ] **Multi-Currency Support**: International currency detection
- [ ] **Real-time Processing**: Webcam integration
- [ ] **Mobile Version**: Cross-platform deployment
- [ ] **API Interface**: REST API for integration
- [ ] **Database Integration**: Transaction logging

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 🙏 Acknowledgments

- Computer Vision algorithms based on standard image processing techniques
- Morphological operations implementation
- Connected component analysis algorithms
- Windows Forms UI framework

---

**Note**: This system is designed for educational and research purposes. For production use in financial applications, additional security measures and accuracy improvements would be required.