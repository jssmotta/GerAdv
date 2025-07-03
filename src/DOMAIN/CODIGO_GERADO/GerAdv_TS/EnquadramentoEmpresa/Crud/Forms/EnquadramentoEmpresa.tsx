// Tracking: Forms.tsx.txt
'use client';
import { IEnquadramentoEmpresa } from '@/app/GerAdv_TS/EnquadramentoEmpresa/Interfaces/interface.EnquadramentoEmpresa';
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
import { EnquadramentoEmpresaApi } from '../../Apis/ApiEnquadramentoEmpresa';
import { useValidationsEnquadramentoEmpresa } from '../../Hooks/hookEnquadramentoEmpresa';
import InputName from '@/app/components/Inputs/InputName';
interface EnquadramentoEmpresaFormProps {
  enquadramentoempresaData: IEnquadramentoEmpresa;
  onChange: (e: any) => void;
  onSubmit: (e: React.FormEvent) => void;
  onClose: () => void;
  onError?: () => void;
  onReload?: () => void;
  onSuccess?: (registro?: any) => void;
}

export const EnquadramentoEmpresaForm: React.FC<EnquadramentoEmpresaFormProps> = ({
  enquadramentoempresaData, 
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
const dadoApi = new EnquadramentoEmpresaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [isSubmitting, setIsSubmitting] = useState(false);
const initialized = useRef(false);
const validationForm = useValidationsEnquadramentoEmpresa();

const onConfirm = (e: React.FormEvent) => {
  e.preventDefault();
  if (e.stopPropagation) e.stopPropagation();

    if (!isSubmitting) {
      setIsSubmitting(true);

      try {
        onSubmit(e);
      } catch (error) {
      console.error('Erro ao submeter formulário de EnquadramentoEmpresa:', error);
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
        target: document.getElementById(`EnquadramentoEmpresaForm-${enquadramentoempresaData.id}`)
      } as unknown as React.FormEvent;

      onSubmit(syntheticEvent);
    } catch (error) {
    console.error('Erro ao salvar EnquadramentoEmpresa diretamente:', error);
    setIsSubmitting(false);
    if (onError) onError();
    }
  }
};
useEffect(() => {
  const el = document.querySelector('.nameFormMobile');
  if (el) {
    el.textContent = enquadramentoempresaData?.id == 0 ? 'Editar EnquadramentoEmpresa' : 'Adicionar Enquadramento Empresa';
  }
}, [enquadramentoempresaData.id]);
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

  <div className={isMobile ? 'form-container form-container-EnquadramentoEmpresa' : 'form-container5 form-container-EnquadramentoEmpresa'}>

    <form className='formInputCadInc' id={`EnquadramentoEmpresaForm-${enquadramentoempresaData.id}`} onSubmit={onConfirm}>
      {!isMobile && (
        <ButtonSalvarCrud isMobile={false} validationForm={validationForm} entity='EnquadramentoEmpresa' data={enquadramentoempresaData} isSubmitting={isSubmitting} onClose={onClose} formId={`EnquadramentoEmpresaForm-${enquadramentoempresaData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
        )}
        <div className='grid-container'>

          <InputName
          type='text'
          id='nome'
          label='Nome'
          dataForm={enquadramentoempresaData}
          className='inputIncNome'
          name='nome'
          value={enquadramentoempresaData.nome}
          placeholder={`Informe Nome`}
          onChange={onChange}
          required
          />

        </div>
      </form>


      {isMobile && (
        <ButtonSalvarCrud isMobile={true} validationForm={validationForm} entity='EnquadramentoEmpresa' data={enquadramentoempresaData} isSubmitting={isSubmitting} onClose={onClose} formId={`EnquadramentoEmpresaForm-${enquadramentoempresaData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
        )}
        <DeleteButton page={'/pages/enquadramentoempresa'} id={enquadramentoempresaData.id} closeModel={onClose} dadoApi={dadoApi} />
      </div>
      <div className='form-spacer'></div>
      </>
    );
  };