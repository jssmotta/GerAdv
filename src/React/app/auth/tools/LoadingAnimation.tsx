'use client';
import React, { useState, useEffect } from 'react';

const LoadingAnimation: React.FC<{ text: string }> = ({ text }) => {
  const [activeIndex, setActiveIndex] = useState<number>(0);

  useEffect(() => {
    const interval = window.setInterval(() => {
      setActiveIndex((prev) => (prev + 1) % text.length);
    }, 333);

    return () => window.clearInterval(interval);
  }, [text.length]);

  // Keep layout where this component is placed (no centering/background)
  const containerStyle: React.CSSProperties = {};

  const textContainerStyle: React.CSSProperties = {};

  const baseSpanStyle: React.CSSProperties = {
    display: 'inline-block',
    transition: 'font-size 200ms ease, font-weight 200ms ease, color 200ms ease',
    // keep normal spacing between letters; do not force margins
  };

  return (
    <div style={containerStyle}>
      <div style={textContainerStyle}>
        {text.split('').map((char: string, index: number) => {
          const isActive = index === activeIndex;
          const spanStyle: React.CSSProperties = {
            ...baseSpanStyle,
            color: isActive ? '#000' : 'inherit', // active letter in black, others inherit surrounding color
            fontSize: isActive ? '1.15em' : '1em',
            fontWeight: isActive ? 700 : 400,
          };

          return (
            <span key={index} style={spanStyle}>
              {char}
            </span>
          );
        })}
      </div>
    </div>
  );
};

export default LoadingAnimation;