'use client';
import React, { useState } from 'react';
import { Button } from '@progress/kendo-react-buttons';

interface ButtonCopyClipboardProps {
  textToClipboard: string;
}

const CopyIcon = () => (
  <svg width="16" height="16" fill="currentColor" viewBox="0 0 24 24">
    <rect
      x="9"
      y="9"
      width="13"
      height="13"
      rx="2"
      fill="none"
      stroke="currentColor"
      strokeWidth="2"
    />
    <rect
      x="3"
      y="3"
      width="13"
      height="13"
      rx="2"
      fill="none"
      stroke="currentColor"
      strokeWidth="2"
    />
  </svg>
);

export const ButtonCopyClipboard: React.FC<ButtonCopyClipboardProps> = ({
  textToClipboard,
}) => {
  const [copied, setCopied] = useState(false);

  const handleCopy = async () => {
    try {
      await navigator.clipboard.writeText(textToClipboard);
      setCopied(true);
      setTimeout(() => setCopied(false), 1500);
    } catch (err) {
      setCopied(false);
    }
  };

  return (
    <div className="button-bottom-inc">
      <Button
        className="button-copy-clipboard button-after-button button-cadinc"
        onClick={handleCopy}
        aria-label={copied ? 'Copiado!' : 'Copiar'}
        style={{
          display: 'inline-flex',
          marginTop: '10px',
          maxHeight: '38px',
          color: 'white',
          overflow: 'hidden',
          textOverflow: 'ellipsis',
        }}
      >
        <span style={{ display: 'inline-flex', alignItems: 'center' }}>
          <CopyIcon />
          <span style={{ marginLeft: 8 }}>
            {copied ? 'Copiado!' : 'Copiar'}
          </span>
        </span>
      </Button>
    </div>
  );
};

export default ButtonCopyClipboard;
