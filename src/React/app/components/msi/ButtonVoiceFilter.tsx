'use client';
import React, { useState } from 'react';
import { SvgIcon } from '@progress/kendo-react-common';
import ButtonVoice from '@/app/components/msi/ButtonVoice';
import { microphoneOutlineIcon } from '@progress/kendo-svg-icons';
import { ICommandSpeakerRequest } from '@/app/models/ICommandSpeakerRequest';
import { Button } from '@progress/kendo-react-buttons';

interface ButtonVoiceFilterProps {
  onVoiceFilter: (voiceCommand: ICommandSpeakerRequest) => void;
  disabled?: boolean;
  title?: string;
}

const ButtonVoiceFilter: React.FC<ButtonVoiceFilterProps> = ({
  onVoiceFilter,
  disabled = false,
  title = "Filtro por Comando de Voz"
}) => {
  const [isVoiceDialogOpen, setIsVoiceDialogOpen] = useState(false);

  const handleVoiceMessage = (message: string) => {
    if (!message.trim()) return;

    // Criar objeto de comando de voz para filtro de clientes
    const voiceCommand: ICommandSpeakerRequest = {
      message: message.trim(),
      operation: "filter",
      context: "Clientes",
      additionalInstructions: "Aplicar filtro baseado no comando de voz para buscar clientes"
    };

    // Chamar a função de callback com o comando de voz
    onVoiceFilter(voiceCommand);
  };

  const openVoiceDialog = () => {
    if (disabled) return;
    setIsVoiceDialogOpen(true);
  };

  const closeVoiceDialog = () => {
    setIsVoiceDialogOpen(false);
  };

  return (
    <>
      <Button
        title="Faça filtros ou busque registros com voz"
        className="k-button"
        aria-label="Buscar/Filtrar/Pesquisar com voz"
        onClick={openVoiceDialog}>
        <SvgIcon icon={microphoneOutlineIcon} />
      </Button>
      <ButtonVoice
        isOpen={isVoiceDialogOpen}
        onClose={closeVoiceDialog}
        onVoiceMessage={handleVoiceMessage}
      />
    </>
  );
};

export default ButtonVoiceFilter;
