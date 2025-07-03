// Tracking: Forms.tsx.txt
'use client';
import { ITipoProDesposito } from '@/app/GerAdv_TS/TipoProDesposito/Interfaces/interface.TipoProDesposito';
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
import { TipoProDespositoApi } from '../../Apis/ApiTipoProDesposito';
import { useValidationsTipoProDesposito } from '../../Hooks/hookTipoProDesposito';
import InputName from '@/app/components/Inputs/InputName';
interface TipoProDespositoFormProps {
  tipoprodespositoData: ITipoProDesposito;
  onChange: (e: any) => void;
  onSubmit: (e: React.FormEvent) => void;
  onClose: () => void;
  onError?: () => void;
  onReload?: () => void;
  onSuccess?: (registro?: any) => void;
}

export const TipoProDespositoForm: React.FC<TipoProDespositoFormProps> = ({
  tipoprodespositoData, 
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
const dadoApi = new TipoProDespositoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [isSubmitting, setIsSubmitting] = useState(false);
const initialized = useRef(false);
const validationForm = useValidationsTipoProDesposito();

const onConfirm = (e: React.FormEvent) => {
  e.preventDefault();
  if (e.stopPropagation) e.stopPropagation();

    if (!isSubmitting) {
      setIsSubmitting(true);

      try {
        onSubmit(e);
      } catch (error) {
      console.error('Erro ao submeter formulário de TipoProDesposito:', error);
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
        target: document.getElementById(`TipoProDespositoForm-${tipoprodespositoData.id}`)
      } as unknown as React.FormEvent;

      onSubmit(syntheticEvent);
    } catch (error) {
    console.error('Erro ao salvar TipoProDesposito diretamente:', error);
    setIsSubmitting(false);
    if (onError) onError();
    }
  }
};
useEffect(() => {
  const el = document.querySelector('.nameFormMobile');
  if (el) {
    el.textContent = tipoprodespositoData?.id == 0 ? 'Editar TipoProDesposito' : 'Adicionar Tipo Pro Desposito';
  }
}, [tipoprodespositoData.id]);
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

  <div className={isMobile ? 'form-container form-container-TipoProDesposito' : 'form-container5 form-container-TipoProDesposito'}>

    <form className='formInputCadInc' id={`TipoProDespositoForm-${tipoprodespositoData.id}`} onSubmit={onConfirm}>
      {!isMobile && (
        <ButtonSalvarCrud isMobile={false} validationForm={validationForm} entity='TipoProDesposito' data={tipoprodespositoData} isSubmitting={isSubmitting} onClose={onClose} formId={`TipoProDespositoForm-${tipoprodespositoData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
        )}
        <div className='grid-container'>

          <InputName
          type='text'
          id='nome'
          label='Nome'
          dataForm={tipoprodespositoData}
          className='inputIncNome'
          name='nome'
          value={tipoprodespositoData.nome}
          placeholder={`Informe Nome`}
          onChange={onChange}
          required
          />

        </div>
      </form>


      {isMobile && (
        <ButtonSalvarCrud isMobile={true} validationForm={validationForm} entity='TipoProDesposito' data={tipoprodespositoData} isSubmitting={isSubmitting} onClose={onClose} formId={`TipoProDespositoForm-${tipoprodespositoData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
        )}
        <DeleteButton page={'/pages/tipoprodesposito'} id={tipoprodespositoData.id} closeModel={onClose} dadoApi={dadoApi} />
      </div>
      <div className='form-spacer'></div>
      </>
    );
  };