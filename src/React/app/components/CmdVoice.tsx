'use client';
import React, { useState, useEffect } from 'react';
import { ButtonVoice } from './msi/ButtonVoice';
import { Button } from '@progress/kendo-react-buttons';
import { SvgIcon } from '@progress/kendo-react-common';
import { microphoneOutlineIcon } from '@progress/kendo-svg-icons';
import AgendaCalendaSemana from './HomeAgenda/components/AgendaCalendaSemana';
import { useAppSelector } from '../store/hooks';
import { selectLoginTenantApp, selectSystemContext } from '../store/slices/systemContextSlice';
import { decodeBase64Token } from '../tools/Fetcher';
import AgendaWindowId from '../GerAdv_TS/Agenda/Crud/Grids/AgendaWindowId';
import Layout from '../layout';

const CmdVoice: React.FC = () => {
  const systemContext = useAppSelector(selectSystemContext);
  const loginTenant = useAppSelector(selectLoginTenantApp);
  const [isIOS, setIsIOS] = useState(false);
  const [showVoiceDialog, setShowVoiceDialog] = useState(true);
  const [isAgendaWindowOpen, setIsAgendaWindowOpen] = useState(false);
  const [agendaId, setAgendaId] = useState<number | null>(null);
  const [error, setError] = useState<string | null>(null);
  const [warning, setWarning] = useState<string | null>(null);

  useEffect(() => {
    // Detectar se é iPhone/iOS apenas no cliente
    if (typeof window !== 'undefined' && typeof navigator !== 'undefined') {
      const checkIOS = /iPad|iPhone|iPod/.test(navigator.userAgent);
      setIsIOS(checkIOS);
    }
  }, []);

  const handleVoiceMessage = async (message: string) => {
    console.log('Mensagem de voz recebida:', message);
    
    // Enviar para o endpoint
    await sendToEndpoint(message);
  };

  const sendToEndpoint = async (message: string) => {
    try {
      if (!systemContext?.Token || !loginTenant) {
        const errorMsg = 'Token de autenticação ou URI não encontrados.';
        throw new Error(errorMsg);
      }

      const url = `${process.env.NEXT_PUBLIC_URL_API}/${systemContext?.TenantApp}/CommanderSpeaker`;
      
      const headers = {
        'Authorization': `Bearer ${decodeBase64Token(systemContext.Token)}`,
        'Content-Type': 'application/json',
      };

      const body = JSON.stringify({ message });
      
      const response = await fetch(url, {
        method: 'POST',
        headers,
        body
      });

      if (!response.ok) {
        const errorMsg = `HTTP error! status: ${response.status}`;
        throw new Error(errorMsg);
      }

      const result = await response.text();
      
      // Tentar processar como JSON para extrair agendaId
      if (result && result.trim().length > 0) {
        try {
          const jsonResponse = JSON.parse(result);
          
          // Verificar se existe agendaId válido na resposta
          if (jsonResponse.agendaId && jsonResponse.agendaId > 0) {
            setAgendaId(jsonResponse.agendaId);
            setIsAgendaWindowOpen(true);
          }
        } catch (jsonError) {
          // Resposta não é JSON válido, tratar como texto simples
          console.log('Resposta do servidor (texto):', result);
        }
      }
      
      setError(null);
      setWarning(null);
      
      // Feedback específico baseado na resposta
      if (!result || result.trim() === '') {
        // Mostrar mensagem informativa ao usuário
        setWarning('Comando enviado ao servidor com sucesso, mas não houve resposta específica. A ação pode ter sido executada.');
      }
      
    } catch (err) {
      const errorMessage = err instanceof Error ? err.message : 'Erro desconhecido';
      setError(`Erro ao enviar: ${errorMessage}`);
      console.error('Erro ao processar comando:', errorMessage);
    }
  };

  const handleCloseAgendaWindow = () => {
    setIsAgendaWindowOpen(false);
    setAgendaId(null);
  };

  const handleAgendaSuccess = (registro?: any) => {
    console.log('Agenda salva com sucesso:', registro);
    handleCloseAgendaWindow();
  };

  const handleAgendaError = () => {
    console.error('Erro ao processar agenda');
    handleCloseAgendaWindow();
  };

  const activateVoiceMode = () => {
    // Salvar preferência e redirecionar apenas no cliente
    if (typeof window !== 'undefined') {
      localStorage.setItem('voiceCommandMode', 'true');
      window.location.href = '/?voice=true';
    }
  };

  return (
    <Layout>
      
        <div style={{ marginBottom: '20px', textAlign: 'center' }}>
          {/* Botão para ativar modo voz completo */}
          {isIOS && (
          <Button
            onClick={activateVoiceMode}
            style={{
              padding: '12px 24px',
              backgroundColor: '#34C759',
              color: 'white',
              border: 'none',
              borderRadius: '25px',
              fontSize: '16px',
              fontWeight: '600',
              cursor: 'pointer',
              marginRight: '10px',
              boxShadow: '0 4px 15px rgba(52, 199, 89, 0.3)'
            }}
          >
            <SvgIcon icon={microphoneOutlineIcon} style={{ marginRight: '5px' }} /> Modo Comandos por Voz
          </Button>
          )}
          
          {/* Botão para abrir o diálogo de comando de voz */}
          <Button
            onClick={() => setShowVoiceDialog(true)}
            style={{
              padding: '10px 20px',
              backgroundColor: '#007AFF',
              color: 'white',
              border: 'none',
              borderRadius: '20px',
              fontSize: '14px',
              cursor: 'pointer',
              marginLeft: '10px'  
            }}
          >
            <SvgIcon icon={microphoneOutlineIcon} style={{ marginRight: '5px' }} /> Comando de Voz
          </Button>
          
          {/* Dialog de Comando de Voz */}
          <ButtonVoice
            isOpen={showVoiceDialog}
            onClose={() => setShowVoiceDialog(false)}
            onVoiceMessage={handleVoiceMessage}
            exemplos="Peça para criar um compromisso com Fulano amanhã às 15h"
          />

          {/* Mensagens de erro/warning */}
          {error && (
            <div style={{
              marginTop: '15px',
              padding: '12px',
              backgroundColor: '#ffebee',
              border: '1px solid #ffcdd2',
              borderRadius: '8px',
              color: '#c62828',
              fontSize: '14px',
              textAlign: 'center'
            }}>
              {error}
            </div>
          )}

          {warning && (
            <div style={{
              marginTop: '15px',
              padding: '12px',
              backgroundColor: '#fff3e0',
              border: '1px solid #ffe0b2',
              borderRadius: '8px',
              color: '#e65100',
              fontSize: '14px',
              textAlign: 'center'
            }}>
              {warning}
            </div>
          )}
        </div>
       
       <AgendaCalendaSemana />

       {/* AgendaWindow para abrir quando receber um ID válido */}
       {agendaId && (
        <AgendaWindowId
          isOpen={isAgendaWindowOpen}
          id={agendaId}
          onClose={handleCloseAgendaWindow}
          onSuccess={handleAgendaSuccess}
          onError={handleAgendaError}
        />
      )}
       
    </Layout>
  );
};

export default CmdVoice;
