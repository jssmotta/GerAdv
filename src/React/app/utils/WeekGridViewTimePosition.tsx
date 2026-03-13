/**
 * Utilitário para calcular a posição da linha de tempo atual na grade semanal
 * Centraliza a lógica de posicionamento do indicador de tempo
 */

import React, { useState, useEffect } from 'react';
import { format } from 'date-fns';

/**
 * Calcula a posição vertical da linha de tempo atual
 * @param currentTime - Data/hora atual
 * @returns Posição em pixels a partir do topo do container
 */
export const getCurrentTimePosition = (currentTime: Date): number => {
  const hours = currentTime.getHours();
  const minutes = currentTime.getMinutes();
  
  // Pegar horário de início dos slots (padrão: 8h)
  const startHour = Number(process.env.NEXT_PUBLIC_URL_WEEK_SLOT_START ?? '8');
  
  // ALTURA REAL medida: 37.94px por slot + 1px de borda
  const slotHeight = 37.94; // Altura REAL de cada slot de 1 hora
  const borderHeight = 1; // Borda inferior de cada slot
  const headerHeight = 49.25; // Altura REAL do cabeçalho do dia
  const pageHeaderOffset = 50; // Offset do header fixo da página
  
  // Calcula quantas horas passaram desde o horário de início
  const hoursFromStart = hours - startHour;
  
  // Se estamos antes do horário de início, não mostrar a linha
  if (hoursFromStart < 0) {
    return -100; // Posição fora da tela
  }
  
  // Calcula a posição: pageHeader + dayHeader + (horas desde início * (altura + borda)) + (minutos proporcionais)
  const slotsPassados = hoursFromStart * (slotHeight + borderHeight);
  const minutosProporcionais = (minutes / 60) * slotHeight;
  const position = pageHeaderOffset + headerHeight + slotsPassados + minutosProporcionais;
  
  return position;
};

/**
 * Verifica se o horário atual está dentro do intervalo de slots visíveis
 * @param currentTime - Data/hora atual
 * @returns true se está dentro do intervalo visível
 */
export const isTimeInVisibleRange = (currentTime: Date): boolean => {
  const hours = currentTime.getHours();
  const startHour = Number(process.env.NEXT_PUBLIC_URL_WEEK_SLOT_START ?? '8');
  const endHour = Number(process.env.NEXT_PUBLIC_URL_WEEK_SLOT_END ?? '20');
  
  return hours >= startHour && hours <= endHour;
};

/**
 * Hook personalizado para gerenciar o estado da linha de tempo
 */
export const useCurrentTimeIndicator = () => {
  const [currentTime, setCurrentTime] = useState(new Date());

  useEffect(() => {
    const timer = setInterval(() => {
      setCurrentTime(new Date());
    }, 60000); // Atualiza a cada 1 minuto

    return () => clearInterval(timer);
  }, []);

  return currentTime;
};

/**
 * Componente do indicador de linha de tempo
 */
interface CurrentTimeIndicatorProps {
  currentTime: Date;
}

export const CurrentTimeIndicator: React.FC<CurrentTimeIndicatorProps> = ({ currentTime }) => {
  const position = getCurrentTimePosition(currentTime);

  return (
    <div
      className="current-time-indicator"
      style={{
        position: 'absolute',
        top: `${position}px`,
        left: 0,
        right: 0,
        height: '3px',
        backgroundColor: 'rgba(220, 38, 38, 0.9)',
        zIndex: 9999,
        boxShadow: '0 0 8px rgba(255, 0, 0, 1)',
        pointerEvents: 'none'
      }}
      title={`Horário atual: ${format(currentTime, 'HH:mm')}`}
    >
      {/* Círculo no início da linha */}
      <div
        style={{
          position: 'absolute',
          left: '-6px',
          top: '-4px',
          width: '10px',
          height: '10px',
          backgroundColor: '#ff0000',
          borderRadius: '50%',
          border: '2px solid #ffffff',
          boxShadow: '0 0 6px rgba(255, 0, 0, 1)'
        }}
      />
      {/* Texto do horário */}
      <div
        style={{
          position: 'absolute',
          right: '5px',
          top: '-14px',
          backgroundColor: '#ff0000',
          color: '#ffffff',
          padding: '2px 6px',
          borderRadius: '3px',
          fontSize: '10px',
          fontWeight: 'bold',
          boxShadow: '0 1px 3px rgba(0,0,0,0.3)',
          whiteSpace: 'nowrap'
        }}
      >
        {format(currentTime, 'HH:mm')}
      </div>
    </div>
  );
};
