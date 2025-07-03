// Tracking: Forms.tsx.txt
'use client';
import { IOperadorGrupos } from '@/app/GerAdv_TS/OperadorGrupos/Interfaces/interface.OperadorGrupos';
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
import { OperadorGruposApi } from '../../Apis/ApiOperadorGrupos';
import { useValidationsOperadorGrupos } from '../../Hooks/hookOperadorGrupos';
import InputName from '@/app/components/Inputs/InputName';
interface OperadorGruposFormProps {
  operadorgruposData: IOperadorGrupos;
  onChange: (e: any) => void;
  onSubmit: (e: React.FormEvent) => void;
  onClose: () => void;
  onError?: () => void;
  onReload?: () => void;
  onSuccess?: (registro?: any) => void;
}

export const OperadorGruposForm: React.FC<OperadorGruposFormProps> = ({
  operadorgruposData, 
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
const dadoApi = new OperadorGruposApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [isSubmitting, setIsSubmitting] = useState(false);
const initialized = useRef(false);
const validationForm = useValidationsOperadorGrupos();

const onConfirm = (e: React.FormEvent) => {
  e.preventDefault();
  if (e.stopPropagation) e.stopPropagation();

    if (!isSubmitting) {
      setIsSubmitting(true);

      try {
        onSubmit(e);
      } catch (error) {
      console.error('Erro ao submeter formulário de OperadorGrupos:', error);
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
        target: document.getElementById(`OperadorGruposForm-${operadorgruposData.id}`)
      } as unknown as React.FormEvent;

      onSubmit(syntheticEvent);
    } catch (error) {
    console.error('Erro ao salvar OperadorGrupos diretamente:', error);
    setIsSubmitting(false);
    if (onError) onError();
    }
  }
};
useEffect(() => {
  const el = document.querySelector('.nameFormMobile');
  if (el) {
    el.textContent = operadorgruposData?.id == 0 ? 'Editar OperadorGrupos' : 'Adicionar Operador Grupos';
  }
}, [operadorgruposData.id]);
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

  <div className={isMobile ? 'form-container form-container-OperadorGrupos' : 'form-container5 form-container-OperadorGrupos'}>

    <form className='formInputCadInc' id={`OperadorGruposForm-${operadorgruposData.id}`} onSubmit={onConfirm}>
      {!isMobile && (
        <ButtonSalvarCrud isMobile={false} validationForm={validationForm} entity='OperadorGrupos' data={operadorgruposData} isSubmitting={isSubmitting} onClose={onClose} formId={`OperadorGruposForm-${operadorgruposData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
        )}
        <div className='grid-container'>

          <InputName
          type='text'
          id='nome'
          label='Nome'
          dataForm={operadorgruposData}
          className='inputIncNome'
          name='nome'
          value={operadorgruposData.nome}
          placeholder={`Informe Nome`}
          onChange={onChange}
          required
          />

        </div>
      </form>


      {isMobile && (
        <ButtonSalvarCrud isMobile={true} validationForm={validationForm} entity='OperadorGrupos' data={operadorgruposData} isSubmitting={isSubmitting} onClose={onClose} formId={`OperadorGruposForm-${operadorgruposData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
        )}
        <DeleteButton page={'/pages/operadorgrupos'} id={operadorgruposData.id} closeModel={onClose} dadoApi={dadoApi} />
      </div>
      <div className='form-spacer'></div>
      </>
    );
  };