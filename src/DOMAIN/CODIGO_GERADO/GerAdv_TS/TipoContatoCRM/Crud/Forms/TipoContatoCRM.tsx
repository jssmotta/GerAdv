// Tracking: Forms.tsx.txt
'use client';
import { ITipoContatoCRM } from '@/app/GerAdv_TS/TipoContatoCRM/Interfaces/interface.TipoContatoCRM';
import { useRouter } from 'next/navigation';
import React, { useEffect, useState, useRef } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudFormsBase.css';
import '@/app/styles/CrudFormsMobile.css';
import '@/app/styles/CrudForms5.css'; // [ INDEX_SIZE ]
import ButtonSalvarCrud from '@/app/components/Cruds/ButtonSalvarCrud';
import { useIsMobile } from '@/app/context/MobileContext';
import DeleteButton from '@/app/components/Cruds/DeleteButton';
import { TipoContatoCRMApi } from '../../Apis/ApiTipoContatoCRM';
import { useValidationsTipoContatoCRM } from '../../Hooks/hookTipoContatoCRM';
import InputName from '@/app/components/Inputs/InputName';
interface TipoContatoCRMFormProps {
  tipocontatocrmData: ITipoContatoCRM;
  onChange: (e: any) => void;
  onSubmit: (e: React.FormEvent) => void;
  onClose: () => void;
  onError?: () => void;
  onReload?: () => void;
  onSuccess?: (registro?: any) => void;
}

export const TipoContatoCRMForm: React.FC<TipoContatoCRMFormProps> = ({
  tipocontatocrmData, 
  onChange, 
  onSubmit, 
  onClose, 
  onError, 
  onReload, 
  onSuccess, 
}) => {
const router = useRouter();
const { systemContext } = useSystemContext();
const isMobile = useIsMobile();
const dadoApi = new TipoContatoCRMApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [isSubmitting, setIsSubmitting] = useState(false);
const initialized = useRef(false);
const validationForm = useValidationsTipoContatoCRM();

const onConfirm = (e: React.FormEvent) => {
  e.preventDefault();
  if (e.stopPropagation) e.stopPropagation();

    if (!isSubmitting) {
      setIsSubmitting(true);

      try {
        onSubmit(e);
      } catch (error) {
      console.error('Erro ao submeter formulário de TipoContatoCRM:', error);
      setIsSubmitting(false);
      if (onError) onError();
      }
    }
  };
  const handleCancel = () => {
    if (onReload) {
      onReload(); // Recarrega os dados originais
    } else {
    onClose(); // Comportamento padrão se não há callback de recarga
  }
};

const handleDirectSave = () => {
  if (!isSubmitting) {
    setIsSubmitting(true);

    try {
      const syntheticEvent = {
        preventDefault: () => { }, 
        target: document.getElementById(`TipoContatoCRMForm-${tipocontatocrmData.id}`)
      } as unknown as React.FormEvent;

      onSubmit(syntheticEvent);
    } catch (error) {
    console.error('Erro ao salvar TipoContatoCRM diretamente:', error);
    setIsSubmitting(false);
    if (onError) onError();
    }
  }
};
useEffect(() => {
  const el = document.querySelector('.nameFormMobile');
  if (el) {
    el.textContent = tipocontatocrmData?.id == 0 ? 'Editar TipoContatoCRM' : 'Adicionar Tipo Contato C R M';
  }
}, [tipocontatocrmData.id]);
return (
<>
<style>
  {!isMobile ? `
    @media (max-width: 1366px) {
      html {
        zoom: 0.8 !important;
      }
    }
    ` : ``}
  </style>

  <div className={isMobile ? 'form-container form-container-TipoContatoCRM' : 'form-container5 form-container-TipoContatoCRM'}>

    <form className='formInputCadInc' id={`TipoContatoCRMForm-${tipocontatocrmData.id}`} onSubmit={onConfirm}>
      {!isMobile && (
        <ButtonSalvarCrud isMobile={false} validationForm={validationForm} entity='TipoContatoCRM' data={tipocontatocrmData} isSubmitting={isSubmitting} onClose={onClose} formId={`TipoContatoCRMForm-${tipocontatocrmData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
        )}
        <div className='grid-container'>

          <InputName
          type='text'
          id='nome'
          label='Nome'
          dataForm={tipocontatocrmData}
          className='inputIncNome'
          name='nome'
          value={tipocontatocrmData.nome}
          placeholder={`Informe Nome`}
          onChange={onChange}
          required
          />

        </div>
      </form>


      {isMobile && (
        <ButtonSalvarCrud isMobile={true} validationForm={validationForm} entity='TipoContatoCRM' data={tipocontatocrmData} isSubmitting={isSubmitting} onClose={onClose} formId={`TipoContatoCRMForm-${tipocontatocrmData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
        )}
        <DeleteButton page={'/pages/tipocontatocrm'} id={tipocontatocrmData.id} closeModel={onClose} dadoApi={dadoApi} />
      </div>
      <div className='form-spacer'></div>
      </>
    );
  };