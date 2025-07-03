// Tracking: Forms.tsx.txt
'use client';
import { IProTipoBaixa } from '@/app/GerAdv_TS/ProTipoBaixa/Interfaces/interface.ProTipoBaixa';
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
import { ProTipoBaixaApi } from '../../Apis/ApiProTipoBaixa';
import { useValidationsProTipoBaixa } from '../../Hooks/hookProTipoBaixa';
import InputName from '@/app/components/Inputs/InputName';
interface ProTipoBaixaFormProps {
  protipobaixaData: IProTipoBaixa;
  onChange: (e: any) => void;
  onSubmit: (e: React.FormEvent) => void;
  onClose: () => void;
  onError?: () => void;
  onReload?: () => void;
  onSuccess?: (registro?: any) => void;
}

export const ProTipoBaixaForm: React.FC<ProTipoBaixaFormProps> = ({
  protipobaixaData, 
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
const dadoApi = new ProTipoBaixaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [isSubmitting, setIsSubmitting] = useState(false);
const initialized = useRef(false);
const validationForm = useValidationsProTipoBaixa();

const onConfirm = (e: React.FormEvent) => {
  e.preventDefault();
  if (e.stopPropagation) e.stopPropagation();

    if (!isSubmitting) {
      setIsSubmitting(true);

      try {
        onSubmit(e);
      } catch (error) {
      console.error('Erro ao submeter formulário de ProTipoBaixa:', error);
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
        target: document.getElementById(`ProTipoBaixaForm-${protipobaixaData.id}`)
      } as unknown as React.FormEvent;

      onSubmit(syntheticEvent);
    } catch (error) {
    console.error('Erro ao salvar ProTipoBaixa diretamente:', error);
    setIsSubmitting(false);
    if (onError) onError();
    }
  }
};
useEffect(() => {
  const el = document.querySelector('.nameFormMobile');
  if (el) {
    el.textContent = protipobaixaData?.id == 0 ? 'Editar ProTipoBaixa' : 'Adicionar Pro Tipo Baixa';
  }
}, [protipobaixaData.id]);
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

  <div className={isMobile ? 'form-container form-container-ProTipoBaixa' : 'form-container5 form-container-ProTipoBaixa'}>

    <form className='formInputCadInc' id={`ProTipoBaixaForm-${protipobaixaData.id}`} onSubmit={onConfirm}>
      {!isMobile && (
        <ButtonSalvarCrud isMobile={false} validationForm={validationForm} entity='ProTipoBaixa' data={protipobaixaData} isSubmitting={isSubmitting} onClose={onClose} formId={`ProTipoBaixaForm-${protipobaixaData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
        )}
        <div className='grid-container'>

          <InputName
          type='text'
          id='nome'
          label='Nome'
          dataForm={protipobaixaData}
          className='inputIncNome'
          name='nome'
          value={protipobaixaData.nome}
          placeholder={`Informe Nome`}
          onChange={onChange}
          required
          />

        </div>
      </form>


      {isMobile && (
        <ButtonSalvarCrud isMobile={true} validationForm={validationForm} entity='ProTipoBaixa' data={protipobaixaData} isSubmitting={isSubmitting} onClose={onClose} formId={`ProTipoBaixaForm-${protipobaixaData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
        )}
        <DeleteButton page={'/pages/protipobaixa'} id={protipobaixaData.id} closeModel={onClose} dadoApi={dadoApi} />
      </div>
      <div className='form-spacer'></div>
      </>
    );
  };