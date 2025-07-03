// Tracking: Forms.tsx.txt
'use client';
import { ITipoEnderecoSistema } from '@/app/GerAdv_TS/TipoEnderecoSistema/Interfaces/interface.TipoEnderecoSistema';
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
import { TipoEnderecoSistemaApi } from '../../Apis/ApiTipoEnderecoSistema';
import { useValidationsTipoEnderecoSistema } from '../../Hooks/hookTipoEnderecoSistema';
import InputName from '@/app/components/Inputs/InputName';
interface TipoEnderecoSistemaFormProps {
  tipoenderecosistemaData: ITipoEnderecoSistema;
  onChange: (e: any) => void;
  onSubmit: (e: React.FormEvent) => void;
  onClose: () => void;
  onError?: () => void;
  onReload?: () => void;
  onSuccess?: (registro?: any) => void;
}

export const TipoEnderecoSistemaForm: React.FC<TipoEnderecoSistemaFormProps> = ({
  tipoenderecosistemaData, 
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
const dadoApi = new TipoEnderecoSistemaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [isSubmitting, setIsSubmitting] = useState(false);
const initialized = useRef(false);
const validationForm = useValidationsTipoEnderecoSistema();

const onConfirm = (e: React.FormEvent) => {
  e.preventDefault();
  if (e.stopPropagation) e.stopPropagation();

    if (!isSubmitting) {
      setIsSubmitting(true);

      try {
        onSubmit(e);
      } catch (error) {
      console.error('Erro ao submeter formulário de TipoEnderecoSistema:', error);
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
        target: document.getElementById(`TipoEnderecoSistemaForm-${tipoenderecosistemaData.id}`)
      } as unknown as React.FormEvent;

      onSubmit(syntheticEvent);
    } catch (error) {
    console.error('Erro ao salvar TipoEnderecoSistema diretamente:', error);
    setIsSubmitting(false);
    if (onError) onError();
    }
  }
};
useEffect(() => {
  const el = document.querySelector('.nameFormMobile');
  if (el) {
    el.textContent = tipoenderecosistemaData?.id == 0 ? 'Editar TipoEnderecoSistema' : 'Adicionar Tipo Endereco Sistema';
  }
}, [tipoenderecosistemaData.id]);
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

  <div className={isMobile ? 'form-container form-container-TipoEnderecoSistema' : 'form-container5 form-container-TipoEnderecoSistema'}>

    <form className='formInputCadInc' id={`TipoEnderecoSistemaForm-${tipoenderecosistemaData.id}`} onSubmit={onConfirm}>
      {!isMobile && (
        <ButtonSalvarCrud isMobile={false} validationForm={validationForm} entity='TipoEnderecoSistema' data={tipoenderecosistemaData} isSubmitting={isSubmitting} onClose={onClose} formId={`TipoEnderecoSistemaForm-${tipoenderecosistemaData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
        )}
        <div className='grid-container'>

          <InputName
          type='text'
          id='nome'
          label='Nome'
          dataForm={tipoenderecosistemaData}
          className='inputIncNome'
          name='nome'
          value={tipoenderecosistemaData.nome}
          placeholder={`Informe Nome`}
          onChange={onChange}
          required
          />

        </div>
      </form>


      {isMobile && (
        <ButtonSalvarCrud isMobile={true} validationForm={validationForm} entity='TipoEnderecoSistema' data={tipoenderecosistemaData} isSubmitting={isSubmitting} onClose={onClose} formId={`TipoEnderecoSistemaForm-${tipoenderecosistemaData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
        )}
        <DeleteButton page={'/pages/tipoenderecosistema'} id={tipoenderecosistemaData.id} closeModel={onClose} dadoApi={dadoApi} />
      </div>
      <div className='form-spacer'></div>
      </>
    );
  };