// Tracking: Forms.tsx.txt
'use client';
import { IStatusAndamento } from '@/app/GerAdv_TS/StatusAndamento/Interfaces/interface.StatusAndamento';
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
import { StatusAndamentoApi } from '../../Apis/ApiStatusAndamento';
import { useValidationsStatusAndamento } from '../../Hooks/hookStatusAndamento';
import InputName from '@/app/components/Inputs/InputName';
import InputInput from '@/app/components/Inputs/InputInput'
interface StatusAndamentoFormProps {
  statusandamentoData: IStatusAndamento;
  onChange: (e: any) => void;
  onSubmit: (e: React.FormEvent) => void;
  onClose: () => void;
  onError?: () => void;
  onReload?: () => void;
  onSuccess?: (registro?: any) => void;
}

export const StatusAndamentoForm: React.FC<StatusAndamentoFormProps> = ({
  statusandamentoData, 
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
const dadoApi = new StatusAndamentoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [isSubmitting, setIsSubmitting] = useState(false);
const initialized = useRef(false);
const validationForm = useValidationsStatusAndamento();

const onConfirm = (e: React.FormEvent) => {
  e.preventDefault();
  if (e.stopPropagation) e.stopPropagation();

    if (!isSubmitting) {
      setIsSubmitting(true);

      try {
        onSubmit(e);
      } catch (error) {
      console.error('Erro ao submeter formulário de StatusAndamento:', error);
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
        target: document.getElementById(`StatusAndamentoForm-${statusandamentoData.id}`)
      } as unknown as React.FormEvent;

      onSubmit(syntheticEvent);
    } catch (error) {
    console.error('Erro ao salvar StatusAndamento diretamente:', error);
    setIsSubmitting(false);
    if (onError) onError();
    }
  }
};
useEffect(() => {
  const el = document.querySelector('.nameFormMobile');
  if (el) {
    el.textContent = statusandamentoData?.id == 0 ? 'Editar StatusAndamento' : 'Adicionar Status Andamento';
  }
}, [statusandamentoData.id]);
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

  <div className={isMobile ? 'form-container form-container-StatusAndamento' : 'form-container5 form-container-StatusAndamento'}>

    <form className='formInputCadInc' id={`StatusAndamentoForm-${statusandamentoData.id}`} onSubmit={onConfirm}>
      {!isMobile && (
        <ButtonSalvarCrud isMobile={false} validationForm={validationForm} entity='StatusAndamento' data={statusandamentoData} isSubmitting={isSubmitting} onClose={onClose} formId={`StatusAndamentoForm-${statusandamentoData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
        )}
        <div className='grid-container'>

          <InputName
          type='text'
          id='nome'
          label='Nome'
          dataForm={statusandamentoData}
          className='inputIncNome'
          name='nome'
          value={statusandamentoData.nome}
          placeholder={`Informe Nome`}
          onChange={onChange}
          required
          />

          <InputInput
          type='text'
          maxLength={2048}
          id='icone'
          label='Icone'
          dataForm={statusandamentoData}
          className='inputIncNome'
          name='icone'
          value={statusandamentoData.icone}
          onChange={onChange}
          />

        </div>
      </form>


      {isMobile && (
        <ButtonSalvarCrud isMobile={true} validationForm={validationForm} entity='StatusAndamento' data={statusandamentoData} isSubmitting={isSubmitting} onClose={onClose} formId={`StatusAndamentoForm-${statusandamentoData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
        )}
        <DeleteButton page={'/pages/statusandamento'} id={statusandamentoData.id} closeModel={onClose} dadoApi={dadoApi} />
      </div>
      <div className='form-spacer'></div>
      </>
    );
  };