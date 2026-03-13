'use client';
import React, { useState, useRef, useEffect } from 'react';
import { Dialog, DialogActionsBar } from '@progress/kendo-react-dialogs';
import { Button } from '@progress/kendo-react-buttons';
import { SvgIcon } from '@progress/kendo-react-common';
import { 
  xIcon, 
  plusIcon, 
  clockIcon,
  playIcon,
  arrowRightIcon,
  exclamationCircleIcon,
  pinIcon,
  commentIcon,
  microphoneOutlineIcon
} from '@progress/kendo-svg-icons';

interface ButtonVoiceProps {
  isOpen: boolean;
  onClose: () => void;
  onVoiceMessage: (message: string) => void;
  className?: string;
  exemplos?: string;
}

export const ButtonVoice: React.FC<ButtonVoiceProps> = ({
  isOpen,
  onClose,
  onVoiceMessage,
  className = '',
  exemplos = process.env.NEXT_PUBLIC_VOICE_COMMAND_TIPS || "Peça para filtrar por nomes e datas existentes no cadastro"
}) => {
  const [isListening, setIsListening] = useState(false);
  const [isProcessing, setIsProcessing] = useState(false);
  const [error, setError] = useState<string | null>(null);
  const [isSupported, setIsSupported] = useState(true);
  const [currentTranscript, setCurrentTranscript] = useState('');
  const [textInput, setTextInput] = useState('');
  
  const recognitionRef = useRef<any>(null);
  const timeoutRef = useRef<NodeJS.Timeout | null>(null);
  const silenceTimeoutRef = useRef<NodeJS.Timeout | null>(null);
  const currentTranscriptRef = useRef('');
  const isStoppingRef = useRef(false);
  const isStartingRef = useRef(false);

  // Verificar se é mobile para ajustar tamanho do dialog
  const isMobile = typeof window !== 'undefined' && window.innerWidth <= 768;

  useEffect(() => {
    if (!isOpen) return;

    // Verificar se estamos no cliente
    if (typeof window === 'undefined') {
      return;
    }

    // Verificar suporte a reconhecimento de voz
    const hasSpeechRecognition = typeof window !== 'undefined' && ('webkitSpeechRecognition' in window || 'SpeechRecognition' in window);
    
    if (!hasSpeechRecognition) {
      setIsSupported(false);
      return;
    }

    // Configurar o reconhecimento de voz
    const SpeechRecognition = (window as any).webkitSpeechRecognition || (window as any).SpeechRecognition;
    const recognition = new SpeechRecognition();
    
    // Safari tem problemas com continuous, então usar false em dispositivos iOS
    const isIOS = /iPad|iPhone|iPod/.test(navigator.userAgent);
    recognition.continuous = !isIOS; // Desabilitar continuous no iOS para evitar erro "aborted"
    recognition.interimResults = true;
    recognition.lang = 'pt-BR';
    recognition.maxAlternatives = 1;

    recognition.onstart = () => { 
      setIsListening(true);
      setError(null);
      isStartingRef.current = false;
      isStoppingRef.current = false;
    };

    recognition.onresult = (event: any) => {
      let transcript = '';
      
      // Combinar todos os resultados finais
      for (let i = event.resultIndex; i < event.results.length; i++) {
        if (event.results[i].isFinal) {
          transcript += event.results[i][0].transcript;
        }
      }
      
      // Se há novo texto final, atualizar o transcript acumulado
      if (transcript) { 
        
        // Atualizar a ref e o state
        const newTranscript = (currentTranscriptRef.current + ' ' + transcript).trim();
        currentTranscriptRef.current = newTranscript;
        setCurrentTranscript(newTranscript);
        
        // Resetar o timeout de silêncio
        if (silenceTimeoutRef.current) {
          clearTimeout(silenceTimeoutRef.current);
        }
        
        // Criar novo timeout para detectar 3 segundos de silêncio
        silenceTimeoutRef.current = setTimeout(() => {
          const finalTranscript = currentTranscriptRef.current;
          if (finalTranscript) { 
            // Ao invés de enviar direto, colocar no textarea
            setTextInput(finalTranscript);
            // Parar de escutar
            stopListening();
          }
        }, 3000);
      }
    };

    recognition.onerror = (event: any) => { 
      setIsListening(false);
      setIsProcessing(false);
      isStartingRef.current = false;
      isStoppingRef.current = false;
      
      let errorMessage = 'Erro no reconhecimento de voz';
      switch (event.error) {
        case 'aborted':
          // No Safari, "aborted" pode acontecer ao tentar iniciar quando já está ativo
          // Não mostrar erro ao usuário, apenas resetar
          console.log('Reconhecimento abortado - provavelmente tentou iniciar quando já estava ativo');
          setError(null);
          return;
        case 'no-speech':
          errorMessage = 'Nenhuma fala detectada. Tente novamente.';
          break;
        case 'audio-capture':
          errorMessage = 'Erro no microfone. Verifique as permissões.';
          break;
        case 'not-allowed':
          errorMessage = 'Permissão negada para usar o microfone.';
          break;
        case 'network':
          errorMessage = 'Erro de rede. Verifique sua conexão.';
          break;
        default:
          errorMessage = `Erro: ${event.error}`;
      }
      
      setError(errorMessage);
    };

    recognition.onend = () => { 
      setIsListening(false);
      isStoppingRef.current = false;
      isStartingRef.current = false;
      
      // Limpar timeouts se existirem
      if (timeoutRef.current) {
        clearTimeout(timeoutRef.current);
        timeoutRef.current = null;
      }
      
      if (silenceTimeoutRef.current) {
        clearTimeout(silenceTimeoutRef.current);
        silenceTimeoutRef.current = null;
      }
      
      // No iOS, se continuous=false, o reconhecimento para após detectar fala
      // Reiniciar automaticamente se ainda estamos "escutando"
      const isIOS = /iPad|iPhone|iPod/.test(navigator.userAgent);
      if (isIOS && !isStoppingRef.current && !isProcessing) {
        // Aguardar um pouco antes de reiniciar para evitar erro "aborted"
        setTimeout(() => {
          if (!isStoppingRef.current && !isProcessing && recognitionRef.current) {
            try {
              console.log('Reiniciando reconhecimento no iOS...');
              recognitionRef.current.start();
            } catch (err) {
              console.error('Erro ao reiniciar reconhecimento:', err);
            }
          }
        }, 100);
      }
    };

    recognitionRef.current = recognition;

    return () => {
      if (recognitionRef.current) {
        recognitionRef.current.stop();
      }
      if (timeoutRef.current) {
        clearTimeout(timeoutRef.current);
      }
      if (silenceTimeoutRef.current) {
        clearTimeout(silenceTimeoutRef.current);
      }
    };
  }, [isOpen]);

  const handleSendMessage = (message: string) => {
    if (!message.trim()) return;
    
    setIsProcessing(true);
    setIsListening(false);
    
    // Parar reconhecimento se estiver ativo
    if (recognitionRef.current && isListening) {
      recognitionRef.current.stop();
    }
    
    // Resetar estados
    setCurrentTranscript('');
    currentTranscriptRef.current = '';
    setTextInput('');
    
    // Disparar evento VoiceMessage
    onVoiceMessage(message.trim());
    
    // Fechar dialog após 2 segundos
    setTimeout(() => {
      setIsProcessing(false);
      onClose();
    }, 2000);
  };

  const startListening = () => {
    if (!isSupported || !recognitionRef.current || isListening || isProcessing) {
      return;
    }

    // Prevenir múltiplas tentativas simultâneas de iniciar
    if (isStartingRef.current) { 
      return;
    }

    try {
      isStartingRef.current = true;
      
      // Limpar mensagens anteriores
      setError(null);
      
      // Resetar transcript anterior
      setCurrentTranscript('');
      currentTranscriptRef.current = '';
      isStoppingRef.current = false;
      
      // Timeout de segurança (30 segundos)
      timeoutRef.current = setTimeout(() => {
        if (recognitionRef.current && isListening) {
          isStoppingRef.current = true;
          recognitionRef.current.stop();
        }
      }, 30000);

      recognitionRef.current.start();
    } catch (err: any) { 
      isStartingRef.current = false;
      
      // Se o erro for "already started", tentar parar e reiniciar após delay
      if (err.message && err.message.includes('already')) { 
        try {
          recognitionRef.current.stop();
        } catch (stopErr) { 
        }
        
        // Tentar novamente após um delay
        setTimeout(() => {
          isStartingRef.current = false;
          startListening();
        }, 500);
      } else {
        setError('Erro ao iniciar o reconhecimento de voz.');
      }
    }
  };

  const stopListening = () => {
    if (!recognitionRef.current) return;
    
    // Marcar que estamos parando intencionalmente
    isStoppingRef.current = true;
    
    // Se há texto transcrito, colocar no textarea
    const currentText = currentTranscriptRef.current.trim();
    if (currentText) {
      setTextInput(currentText);
    }
    
    if (isListening) {
      try {
        recognitionRef.current.stop();
      } catch (err) {
        console.error('Erro ao parar reconhecimento:', err);
      }
    }
    
    // Limpar timeouts
    if (silenceTimeoutRef.current) {
      clearTimeout(silenceTimeoutRef.current);
      silenceTimeoutRef.current = null;
    }
    
    if (timeoutRef.current) {
      clearTimeout(timeoutRef.current);
      timeoutRef.current = null;
    }
    
    // Resetar transcript acumulado
    setCurrentTranscript('');
    currentTranscriptRef.current = '';
    setIsListening(false);
  };

  const handleTextSubmit = () => {
    if (!textInput.trim() || isProcessing) return;
    
    handleSendMessage(textInput.trim());
  };

  const handleKeyPress = (e: React.KeyboardEvent) => {
    if (e.key === 'Enter' && !e.shiftKey) {
      e.preventDefault();
      handleTextSubmit();
    }
  };

  const handleClose = () => {
    // Parar reconhecimento se estiver ativo
    if (isListening) {
      isStoppingRef.current = true;
      stopListening();
    }
    
    // Resetar estados
    setCurrentTranscript('');
    setTextInput('');
    setError(null);
    setIsProcessing(false);
    isStartingRef.current = false;
    isStoppingRef.current = false;
    
    onClose();
  };

  if (!isOpen) return null;

  // Verificar se é iOS para decidir qual interface mostrar
  
  const hasSpeechRecognition = typeof window !== 'undefined' && ('webkitSpeechRecognition' in window || 'SpeechRecognition' in window);

  return (
    <React.Fragment>      
      <Dialog
        title={
          <div style={{ display: 'flex', alignItems: 'center', gap: '8px' }}>
            <SvgIcon icon={microphoneOutlineIcon} />
            Comando de Voz
          </div>
        }
        onClose={handleClose}
        width={isMobile ? '100vw' : 'min(500px, 90vw)'}
        height={isMobile ? '100vh' : 'auto'}
        className={`msishad-shadow ${className}`}
      >
      <div style={{
        padding: '20px',
        display: 'flex',
        flexDirection: 'column',
        gap: '20px',
        minHeight: isMobile ? '60vh' : '300px'
      }}>
        {/* Interface de reconhecimento de voz (se suportado) */}
        {hasSpeechRecognition && isSupported && (
          <div style={{
            display: 'flex',
            flexDirection: 'column',
            alignItems: 'center',
            gap: '15px'
          }}>
            <Button
              onClick={isListening ? stopListening : startListening}
              disabled={isProcessing}
              style={{
                width: '80px',
                height: '80px',
                borderRadius: '50%',
                border: 'none',
                backgroundColor: isListening ? '#ff4444' : (isProcessing ? '#ffa500' : '#007acc'),
                color: 'white',
                cursor: isProcessing ? 'not-allowed' : 'pointer',
                display: 'flex',
                alignItems: 'center',
                justifyContent: 'center',
                fontSize: '24px',
                transition: 'all 0.3s ease',
                transform: isListening ? 'scale(1.1)' : 'scale(1)',
                boxShadow: isListening ? '0 0 20px rgba(255, 68, 68, 0.5)' : '0 4px 12px rgba(0, 0, 0, 0.2)'
              }}
              type="button"
              title={isListening ? "Clique para parar de escutar" : "Clique para falar"}
            >
              {isProcessing ? (
                <div style={{
                  width: '20px',
                  height: '20px',
                  border: '2px solid #ffffff',
                  borderTop: '2px solid transparent',
                  borderRadius: '50%',
                  animation: 'spin 1s linear infinite'
                }} />
              ) : (
                <SvgIcon icon={microphoneOutlineIcon} size="large" />
              )}
            </Button>
            
            <div style={{ textAlign: 'center', fontSize: '14px', color: '#666' }}>
              {isProcessing ? (
                <span style={{ color: '#ffa500', fontWeight: 'bold', display: 'flex', alignItems: 'center', gap: '8px', justifyContent: 'center' }}>
                  <SvgIcon icon={clockIcon} />
                  Enviando mensagem...
                </span>
              ) : isListening ? (
                <span style={{ color: '#ff4444', fontWeight: 'bold' }}>
                  Escutando... Clique novamente para parar
                </span>
              ) : (
                <span>
                  Clique no microfone e fale sua mensagem
                </span>
              )}
            </div>
            
            {currentTranscript && isListening && (
              <div style={{
                padding: '10px',
                backgroundColor: '#f0f8ff',
                border: '1px solid #cce7ff',
                borderRadius: '8px',
                fontSize: '14px',
                fontStyle: 'italic',
                color: '#0066cc',
                maxWidth: '100%',
                wordWrap: 'break-word'
              }}>
                <strong>Texto capturado:</strong> {currentTranscript}
              </div>
            )}
          </div>
        )}

        {/* Separador */}
        {hasSpeechRecognition && isSupported && (
          <div style={{
            display: 'flex',
            alignItems: 'center',
            gap: '10px',
            margin: '10px 0'
          }}>
            <hr style={{ flex: 1, border: 'none', borderTop: '1px solid #ddd' }} />
            <span style={{ fontSize: '12px', color: '#999', padding: '0 10px' }}>OU</span>
            <hr style={{ flex: 1, border: 'none', borderTop: '1px solid #ddd' }} />
          </div>
        )}

        {/* Interface de texto sempre disponível */}
        <div style={{
          display: 'flex',
          flexDirection: 'column',
          gap: '10px'
        }}>
          <label style={{ fontSize: '14px', fontWeight: 'bold', color: '#333', display: 'flex', alignItems: 'center', gap: '8px' }}>
            <SvgIcon icon={commentIcon} />
            Digite sua mensagem:
          </label>
          <textarea
            value={textInput}
            onChange={(e) => setTextInput(e.target.value)} 
            onKeyUp={handleKeyPress}
            placeholder="Digite sua mensagem aqui..."
            disabled={isProcessing}
            style={{
              width: '100%',
              minHeight: '80px',
              padding: '12px',
              border: '1px solid #ddd',
              borderRadius: '8px',
              fontSize: '14px',
              resize: 'vertical',
              fontFamily: 'inherit'
            }}
            rows={3}
          />
          
          <Button
            onClick={handleTextSubmit}
            disabled={!textInput.trim() || isProcessing}
            className="k-button k-primary"
            style={{ 
              alignSelf: 'flex-end',
              minWidth: '100px'
            }}
          >
            {isProcessing ? (
              <>
                <div style={{
                  width: '12px',
                  height: '12px',
                  border: '1px solid #ffffff',
                  borderTop: '1px solid transparent',
                  borderRadius: '50%',
                  animation: 'spin 1s linear infinite',
                  marginRight: '8px'
                }} />
                Enviando...
              </>
            ) : (
              <>
                <SvgIcon icon={arrowRightIcon} style={{ marginRight: '5px' }} />
                Enviar
              </>
            )}
          </Button>
        </div>

        {/* Mensagens de erro */}
        {error && (
          <div style={{
            padding: '12px',
            backgroundColor: '#ffebee',
            border: '1px solid #ffcdd2',
            borderRadius: '8px',
            color: '#c62828',
            fontSize: '14px',
            textAlign: 'center'
          }}>
            <SvgIcon icon={exclamationCircleIcon} style={{ marginRight: '5px' }} /> {error}
          </div>
        )}

        {/* Instruções */}
        {!isProcessing && (
          <div style={{
            padding: '12px',
            backgroundColor: '#f3f4f6',
            borderRadius: '8px',
            fontSize: '13px',
            color: '#666',
            textAlign: 'center',
            lineHeight: '1.4'
          }}>
            {hasSpeechRecognition && isSupported ? (
              <>
                <strong><SvgIcon icon={pinIcon} style={{ marginRight: '5px' }} />Como usar:</strong>
                <br />
                <SvgIcon icon={microphoneOutlineIcon} style={{ marginRight: '5px' }} />Clique no microfone e fale. 
                <br />
                Após 3s de silêncio ou ao clicar novamente, o texto vai para a caixa de texto.
                <br />
                <SvgIcon icon={commentIcon} style={{ marginRight: '5px' }} />Revise e clique em "Enviar" quando quiser.
                <br />
                <em>{exemplos}</em>
              </>
            ) : (
              <>
                Digite sua mensagem na caixa de texto acima e clique em "Enviar".
              </>
            )}
          </div>
        )}
      </div>

      <DialogActionsBar>
        <Button
          onClick={handleClose}
          disabled={isProcessing}
          className="k-button"
        >
          <SvgIcon icon={xIcon as any} style={{ marginRight: '5px' }} />
          Fechar
        </Button>
      </DialogActionsBar>

      {/* Adicionar estilo de animação para spinner */}
      <style jsx>{`
        @keyframes spin {
          0% { transform: rotate(0deg); }
          100% { transform: rotate(360deg); }
        }
      `}</style>
      </Dialog>
    </React.Fragment>
  );
};

export default ButtonVoice;
