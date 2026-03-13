"use client";

import React, { useRef, useEffect, useState } from 'react';
import { Button } from '@progress/kendo-react-buttons';
import { useIsMobile } from '@/app/context/MobileContext';
import { EditWindow } from './Cruds/EditWindow';

interface CopyContentDialogProps {
  isOpen: boolean;
  onClose: () => void;
  content: string;
  title?: string;
}

export const CopyContentDialog: React.FC<CopyContentDialogProps> = ({
  isOpen,
  onClose,
  content,
  title = 'Conteúdo Copiado'
}) => {
  const textAreaRef = useRef<HTMLTextAreaElement>(null);
  const isMobile = useIsMobile();
  const [copied, setCopied] = useState(false);

  useEffect(() => {
    if (isOpen && textAreaRef.current) {
      // Selecionar todo o texto quando o dialog abrir
      textAreaRef.current.select();
    }
  }, [isOpen]);

  const handleCopyToClipboard = () => {
    if (textAreaRef.current) {
      textAreaRef.current.select();
      navigator.clipboard.writeText(content).then(() => {
        setCopied(true);
        setTimeout(() => setCopied(false), 2000);
      }).catch(() => {
        // Fallback
        try {
          document.execCommand('copy');
          setCopied(true);
          setTimeout(() => setCopied(false), 2000);
        } catch (err) {
          console.error('Erro ao copiar:', err);
        }
      });
    }
  };

  const handleSelectAll = () => {
    if (textAreaRef.current) {
      textAreaRef.current.select();
    }
  };

  if (!isOpen) return null;

  const windowHeight = typeof window !== 'undefined' ? window.innerHeight : 800;
  const windowWidth = typeof window !== 'undefined' ? window.innerWidth : 400;

  return (
    <EditWindow
      tableTitle={title}
      isOpen={isOpen}
      onClose={onClose}
      dimensions={{
        width: isMobile ? windowWidth * 0.95 : 620,
        height: isMobile ? windowHeight * 0.8 : windowHeight,         
      }}
      newWidth={isMobile ? undefined : 620}
      mobile={isMobile}
    >
      <div style={{ 
        display: 'flex', 
        flexDirection: 'column', 
        height: '95%',
        padding: isMobile ? '10px' : '15px'
      }}>
        <p style={{ 
          margin: '0 0 10px 0', 
          fontSize: isMobile ? '13px' : '14px',
          color: '#666'
        }}>
          Selecione o texto abaixo para copiar apenas o que desejar:
        </p>
        <textarea
          ref={textAreaRef}
          value={content}
          readOnly
          style={{
            flex: 1,
            width: '100%',
            padding: '10px',
            fontSize: isMobile ? '13px' : '14px',
            fontFamily: 'monospace',
            border: '1px solid #ccc',
            borderRadius: '4px',
            resize: 'none',
            outline: 'none',
            lineHeight: '1.5'
          }}
        />
        <div style={{ 
          display: 'flex', 
          gap: '10px', 
          justifyContent: 'flex-end',
          marginTop: '15px',
          paddingTop: '15px',
          borderTop: '1px solid #ccc'
        }}>
          <Button 
            aria-label="Selecionar Tudo"
            className="k-button" 
            title='Clique para selecionar todo o conteúdo'
            onClick={handleSelectAll}
          >
            Selecionar Tudo
          </Button>
          <Button 
            aria-label={copied ? "Copiado!" : "Copiar Tudo"}
            title={"Clique para copiar todo o conteúdo para a área de transferência"}
            className={copied ? "k-button k-primary" : "k-button k-primary"} 
            onClick={handleCopyToClipboard}
            disabled={copied}
          >
            {copied ? '✓ Copiado!' : 'Copiar Tudo'}
          </Button>
          <Button 
            aria-label="Fechar"
            className="k-button" 
            title='Clique para fechar esta caixa de diálogo'
            onClick={onClose}
          >
            Fechar
          </Button>
        </div>
      </div>
    </EditWindow>
  );
};
