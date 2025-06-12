// Tracking: Forms.tsx.txt
'use client';
import { ITipoOrigemSucumbencia } from '@/app/GerAdv_TS/TipoOrigemSucumbencia/Interfaces/interface.TipoOrigemSucumbencia';
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
import { TipoOrigemSucumbenciaApi } from '../../Apis/ApiTipoOrigemSucumbencia';
import { useValidationsTipoOrigemSucumbencia } from '../../Hooks/hookTipoOrigemSucumbencia';
import InputName from '@/app/components/Inputs/InputName';
interface TipoOrigemSucumbenciaFormProps {
  tipoorigemsucumbenciaData: ITipoOrigemSucumbencia;
  onChange: (e: any) => void;
  onSubmit: (e: React.FormEvent) => void;
  onClose: () => void;
  onError?: () => void;
  onReload?: () => void;
  onSuccess?: (registro?: any) => void;
}

export const TipoOrigemSucumbenciaForm: React.FC<TipoOrigemSucumbenciaFormProps> = ({
  tipoorigemsucumbenciaData, 
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
const dadoApi = new TipoOrigemSucumbenciaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [isSubmitting, setIsSubmitting] = useState(false);
const initialized = useRef(false);
const validationForm = useValidationsTipoOrigemSucumbencia();

const onConfirm = (e: React.FormEvent) => {
  e.preventDefault();
  if (e.stopPropagation) e.stopPropagation();

    if (!isSubmitting) {
      setIsSubmitting(true);

      try {
        onSubmit(e);
      } catch (error) {
      console.error('Erro ao submeter formulário de TipoOrigemSucumbencia:', error);
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
        target: document.getElementById(`TipoOrigemSucumbenciaForm-${tipoorigemsucumbenciaData.id}`)
      } as unknown as React.FormEvent;

      onSubmit(syntheticEvent);
    } catch (error) {
    console.error('Erro ao salvar TipoOrigemSucumbencia diretamente:', error);
    setIsSubmitting(false);
    if (onError) onError();
    }
  }
};
useEffect(() => {
  const el = document.querySelector('.nameFormMobile');
  if (el) {
    el.textContent = tipoorigemsucumbenciaData?.id == 0 ? 'Editar TipoOrigemSucumbencia' : 'Adicionar Tipo Origem Sucumbencia';
  }
}, [tipoorigemsucumbenciaData.id]);
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

  <div className={isMobile ? 'form-container form-container-TipoOrigemSucumbencia' : 'form-container5 form-container-TipoOrigemSucumbencia'}>

    <form className='formInputCadInc' id={`TipoOrigemSucumbenciaForm-${tipoorigemsucumbenciaData.id}`} onSubmit={onConfirm}>
      {!isMobile && (
        <ButtonSalvarCrud isMobile={false} validationForm={validationForm} entity='TipoOrigemSucumbencia' data={tipoorigemsucumbenciaData} isSubmitting={isSubmitting} onClose={onClose} formId={`TipoOrigemSucumbenciaForm-${tipoorigemsucumbenciaData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
        )}
        <div className='grid-container'>

          <InputName
          type='text'
          id='nome'
          label='Nome'
          dataForm={tipoorigemsucumbenciaData}
          className='inputIncNome'
          name='nome'
          value={tipoorigemsucumbenciaData.nome}
          placeholder={`Informe Nome`}
          onChange={onChange}
          required
          />

        </div>
      </form>


      {isMobile && (
        <ButtonSalvarCrud isMobile={true} validationForm={validationForm} entity='TipoOrigemSucumbencia' data={tipoorigemsucumbenciaData} isSubmitting={isSubmitting} onClose={onClose} formId={`TipoOrigemSucumbenciaForm-${tipoorigemsucumbenciaData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
        )}
        <DeleteButton page={'/pages/tipoorigemsucumbencia'} id={tipoorigemsucumbenciaData.id} closeModel={onClose} dadoApi={dadoApi} />
      </div>
      <div className='form-spacer'></div>
      </>
    );
  };