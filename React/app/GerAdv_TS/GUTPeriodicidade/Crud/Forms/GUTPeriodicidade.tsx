// Tracking: Forms.tsx.txt
'use client';
import { IGUTPeriodicidade } from '@/app/GerAdv_TS/GUTPeriodicidade/Interfaces/interface.GUTPeriodicidade';
import { useRouter } from 'next/navigation';
import { useEffect, useState, useRef } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudFormsBase.css';
import '@/app/styles/CrudFormsMobile.css';
import '@/app/styles/Inputs.css';
import '@/app/styles/CrudForms5.css'; // [ INDEX_SIZE ]
import ButtonSalvarCrud from '@/app/components/Cruds/ButtonSalvarCrud';
import { useIsMobile } from '@/app/context/MobileContext';
import DeleteButton from '@/app/components/Cruds/DeleteButton';
import { GUTPeriodicidadeApi } from '../../Apis/ApiGUTPeriodicidade';
import { useValidationsGUTPeriodicidade } from '../../Hooks/hookGUTPeriodicidade';
import InputName from '@/app/components/Inputs/InputName';
import InputInput from '@/app/components/Inputs/InputInput'
interface GUTPeriodicidadeFormProps {
  gutperiodicidadeData: IGUTPeriodicidade;
  onChange: (e: any) => void;
  onSubmit: (e: React.FormEvent) => void;
  onClose: () => void;
  onError?: () => void;
  onReload?: () => void;
  onSuccess?: (registro?: any) => void;
}

export const GUTPeriodicidadeForm: React.FC<GUTPeriodicidadeFormProps> = ({
  gutperiodicidadeData, 
  onChange, 
  onSubmit, 
  onClose, 
  onError, 
  onReload, 
  onSuccess, 
}) => {
const router = useRouter();
const isMobile = useIsMobile();
const { systemContext } = useSystemContext();
const dadoApi = new GUTPeriodicidadeApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [isSubmitting, setIsSubmitting] = useState(false);
const initialized = useRef(false);
const validationForm = useValidationsGUTPeriodicidade();

const onConfirm = (e: React.FormEvent) => {
  e.preventDefault();
  if (e.stopPropagation) e.stopPropagation();

    if (!isSubmitting) {
      setIsSubmitting(true);

      try {
        onSubmit(e);
      } catch (error) {
      console.error('Erro ao submeter formulário de GUTPeriodicidade:', error);
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
        target: document.getElementById(`GUTPeriodicidadeForm-${gutperiodicidadeData.id}`)
      } as unknown as React.FormEvent;

      onSubmit(syntheticEvent);
    } catch (error) {
    console.error('Erro ao salvar GUTPeriodicidade diretamente:', error);
    setIsSubmitting(false);
    if (onError) onError();
    }
  }
};
useEffect(() => {
  const el = document.querySelector('.nameFormMobile');
  if (el) {
    el.textContent = gutperiodicidadeData?.id == 0 ? 'Editar GUTPeriodicidade' : 'Adicionar G U T Periodicidade';
  }
}, [gutperiodicidadeData.id]);
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

  <div className={isMobile ? 'form-container form-container-GUTPeriodicidade' : 'form-container5 form-container-GUTPeriodicidade'}>

    <form className='formInputCadInc' id={`GUTPeriodicidadeForm-${gutperiodicidadeData.id}`} onSubmit={onConfirm}>
      {!isMobile && (
        <ButtonSalvarCrud isMobile={false} validationForm={validationForm} entity='GUTPeriodicidade' data={gutperiodicidadeData} isSubmitting={isSubmitting} onClose={onClose} formId={`GUTPeriodicidadeForm-${gutperiodicidadeData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
        )}
        <div className='grid-container'>

          <InputName
          type='text'
          id='nome'
          label='Nome'
          dataForm={gutperiodicidadeData}
          className='inputIncNome'
          name='nome'
          value={gutperiodicidadeData.nome}
          placeholder={`Informe Nome`}
          onChange={onChange}
          required
          />

          <InputInput
          type='text'
          maxLength={2048}
          id='intervalodias'
          label='IntervaloDias'
          dataForm={gutperiodicidadeData}
          className='inputIncNome'
          name='intervalodias'
          value={gutperiodicidadeData.intervalodias}
          onChange={onChange}
          />

        </div>
      </form>


      {isMobile && (
        <ButtonSalvarCrud isMobile={true} validationForm={validationForm} entity='GUTPeriodicidade' data={gutperiodicidadeData} isSubmitting={isSubmitting} onClose={onClose} formId={`GUTPeriodicidadeForm-${gutperiodicidadeData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
        )}
        <DeleteButton page={'/pages/gutperiodicidade'} id={gutperiodicidadeData.id} closeModel={onClose} dadoApi={dadoApi} />
      </div>
      <div className='form-spacer'></div>
      </>
    );
  };