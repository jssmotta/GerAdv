// Tracking: Forms.tsx.txt
'use client';
import { ICargosEsc } from '@/app/GerAdv_TS/CargosEsc/Interfaces/interface.CargosEsc';
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
import { CargosEscApi } from '../../Apis/ApiCargosEsc';
import { useValidationsCargosEsc } from '../../Hooks/hookCargosEsc';
import InputName from '@/app/components/Inputs/InputName';
import InputInput from '@/app/components/Inputs/InputInput'
interface CargosEscFormProps {
  cargosescData: ICargosEsc;
  onChange: (e: any) => void;
  onSubmit: (e: React.FormEvent) => void;
  onClose: () => void;
  onError?: () => void;
  onReload?: () => void;
  onSuccess?: (registro?: any) => void;
}

export const CargosEscForm: React.FC<CargosEscFormProps> = ({
  cargosescData, 
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
const dadoApi = new CargosEscApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [isSubmitting, setIsSubmitting] = useState(false);
const initialized = useRef(false);
const validationForm = useValidationsCargosEsc();

const onConfirm = (e: React.FormEvent) => {
  e.preventDefault();
  if (e.stopPropagation) e.stopPropagation();

    if (!isSubmitting) {
      setIsSubmitting(true);

      try {
        onSubmit(e);
      } catch (error) {
      console.error('Erro ao submeter formulário de CargosEsc:', error);
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
        target: document.getElementById(`CargosEscForm-${cargosescData.id}`)
      } as unknown as React.FormEvent;

      onSubmit(syntheticEvent);
    } catch (error) {
    console.error('Erro ao salvar CargosEsc diretamente:', error);
    setIsSubmitting(false);
    if (onError) onError();
    }
  }
};
useEffect(() => {
  const el = document.querySelector('.nameFormMobile');
  if (el) {
    el.textContent = cargosescData?.id == 0 ? 'Editar CargosEsc' : 'Adicionar Cargos Esc';
  }
}, [cargosescData.id]);
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

  <div className={isMobile ? 'form-container form-container-CargosEsc' : 'form-container5 form-container-CargosEsc'}>

    <form className='formInputCadInc' id={`CargosEscForm-${cargosescData.id}`} onSubmit={onConfirm}>
      {!isMobile && (
        <ButtonSalvarCrud isMobile={false} validationForm={validationForm} entity='CargosEsc' data={cargosescData} isSubmitting={isSubmitting} onClose={onClose} formId={`CargosEscForm-${cargosescData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
        )}
        <div className='grid-container'>

          <InputName
          type='text'
          id='nome'
          label='Nome'
          dataForm={cargosescData}
          className='inputIncNome'
          name='nome'
          value={cargosescData.nome}
          placeholder={`Informe Nome`}
          onChange={onChange}
          required
          />

          <InputInput
          type='text'
          maxLength={2048}
          id='percentual'
          label='Percentual'
          dataForm={cargosescData}
          className='inputIncNome'
          name='percentual'
          value={cargosescData.percentual}
          onChange={onChange}
          />


          <InputInput
          type='text'
          maxLength={2048}
          id='classificacao'
          label='Classificacao'
          dataForm={cargosescData}
          className='inputIncNome'
          name='classificacao'
          value={cargosescData.classificacao}
          onChange={onChange}
          />

        </div>
      </form>


      {isMobile && (
        <ButtonSalvarCrud isMobile={true} validationForm={validationForm} entity='CargosEsc' data={cargosescData} isSubmitting={isSubmitting} onClose={onClose} formId={`CargosEscForm-${cargosescData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
        )}
        <DeleteButton page={'/pages/cargosesc'} id={cargosescData.id} closeModel={onClose} dadoApi={dadoApi} />
      </div>
      <div className='form-spacer'></div>
      </>
    );
  };