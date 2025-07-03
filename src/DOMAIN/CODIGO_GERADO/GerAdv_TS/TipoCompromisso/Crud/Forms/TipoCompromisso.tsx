// Tracking: Forms.tsx.txt
'use client';
import { ITipoCompromisso } from '@/app/GerAdv_TS/TipoCompromisso/Interfaces/interface.TipoCompromisso';
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
import { TipoCompromissoApi } from '../../Apis/ApiTipoCompromisso';
import { useValidationsTipoCompromisso } from '../../Hooks/hookTipoCompromisso';
import InputDescription from '@/app/components/Inputs/InputDescription';
import InputIconeAgenda from '@/app/components/Inputs/InputIconeAgenda'
import InputCheckbox from '@/app/components/Inputs/InputCheckbox';
interface TipoCompromissoFormProps {
  tipocompromissoData: ITipoCompromisso;
  onChange: (e: any) => void;
  onSubmit: (e: React.FormEvent) => void;
  onClose: () => void;
  onError?: () => void;
  onReload?: () => void;
  onSuccess?: (registro?: any) => void;
}

export const TipoCompromissoForm: React.FC<TipoCompromissoFormProps> = ({
  tipocompromissoData, 
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
const dadoApi = new TipoCompromissoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [isSubmitting, setIsSubmitting] = useState(false);
const initialized = useRef(false);
const validationForm = useValidationsTipoCompromisso();

const onConfirm = (e: React.FormEvent) => {
  e.preventDefault();
  if (e.stopPropagation) e.stopPropagation();

    if (!isSubmitting) {
      setIsSubmitting(true);

      try {
        onSubmit(e);
      } catch (error) {
      console.error('Erro ao submeter formulário de TipoCompromisso:', error);
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
        target: document.getElementById(`TipoCompromissoForm-${tipocompromissoData.id}`)
      } as unknown as React.FormEvent;

      onSubmit(syntheticEvent);
    } catch (error) {
    console.error('Erro ao salvar TipoCompromisso diretamente:', error);
    setIsSubmitting(false);
    if (onError) onError();
    }
  }
};
useEffect(() => {
  const el = document.querySelector('.nameFormMobile');
  if (el) {
    el.textContent = tipocompromissoData?.id == 0 ? 'Editar TipoCompromisso' : 'Adicionar Tipo Compromisso';
  }
}, [tipocompromissoData.id]);
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

  <div className={isMobile ? 'form-container form-container-TipoCompromisso' : 'form-container5 form-container-TipoCompromisso'}>

    <form className='formInputCadInc' id={`TipoCompromissoForm-${tipocompromissoData.id}`} onSubmit={onConfirm}>
      {!isMobile && (
        <ButtonSalvarCrud isMobile={false} validationForm={validationForm} entity='TipoCompromisso' data={tipocompromissoData} isSubmitting={isSubmitting} onClose={onClose} formId={`TipoCompromissoForm-${tipocompromissoData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
        )}
        <div className='grid-container'>

          <InputDescription
          type='text'
          id='descricao'
          label='tipo compromisso'
          dataForm={tipocompromissoData}
          className='inputIncNome'
          name='descricao'
          value={tipocompromissoData.descricao}
          placeholder={`Digite nome tipo compromisso`}
          onChange={onChange}
          required
          disabled={tipocompromissoData.id > 0}
          />

          <InputIconeAgenda
          type='text'
          maxLength={2048}
          id='icone'
          label='Icone'
          dataForm={tipocompromissoData}
          className='inputIncNome'
          name='icone'
          value={tipocompromissoData.icone}
          onChange={onChange}
          />

          <InputCheckbox dataForm={tipocompromissoData} label='Financeiro' name='financeiro' checked={tipocompromissoData.financeiro} onChange={onChange} />
        </div>
      </form>


      {isMobile && (
        <ButtonSalvarCrud isMobile={true} validationForm={validationForm} entity='TipoCompromisso' data={tipocompromissoData} isSubmitting={isSubmitting} onClose={onClose} formId={`TipoCompromissoForm-${tipocompromissoData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
        )}
        <DeleteButton page={'/pages/tipocompromisso'} id={tipocompromissoData.id} closeModel={onClose} dadoApi={dadoApi} />
      </div>
      <div className='form-spacer'></div>
      </>
    );
  };