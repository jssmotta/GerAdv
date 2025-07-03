// Tracking: Forms.tsx.txt
'use client';
import { IPrecatoria } from '@/app/GerAdv_TS/Precatoria/Interfaces/interface.Precatoria';
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
import { PrecatoriaApi } from '../../Apis/ApiPrecatoria';
import { useValidationsPrecatoria } from '../../Hooks/hookPrecatoria';
import ProcessosComboBox from '@/app/GerAdv_TS/Processos/ComboBox/Processos';
import { ProcessosApi } from '@/app/GerAdv_TS/Processos/Apis/ApiProcessos';
import InputName from '@/app/components/Inputs/InputName';
import InputInput from '@/app/components/Inputs/InputInput'
interface PrecatoriaFormProps {
  precatoriaData: IPrecatoria;
  onChange: (e: any) => void;
  onSubmit: (e: React.FormEvent) => void;
  onClose: () => void;
  onError?: () => void;
  onReload?: () => void;
  onSuccess?: (registro?: any) => void;
}

export const PrecatoriaForm: React.FC<PrecatoriaFormProps> = ({
  precatoriaData, 
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
const dadoApi = new PrecatoriaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [isSubmitting, setIsSubmitting] = useState(false);
const initialized = useRef(false);
const validationForm = useValidationsPrecatoria();
const [nomeProcessos, setNomeProcessos] = useState('');
const processosApi = new ProcessosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

if (getParamFromUrl('processos') > 0) {
  if (precatoriaData.id === 0 && precatoriaData.processo == 0) {
    processosApi
    .getById(getParamFromUrl('processos'))
    .then((response) => {
      setNomeProcessos(response.data.nropasta);
    })
    .catch((error) => {
      console.error(error);
    });

    precatoriaData.processo = getParamFromUrl('processos');
  }
}
const addValorProcesso = (e: any) => {
  if (e?.id>0)
    precatoriaData.processo = e.id;
  };
  const onConfirm = (e: React.FormEvent) => {
    e.preventDefault();
    if (e.stopPropagation) e.stopPropagation();

      if (!isSubmitting) {
        setIsSubmitting(true);

        try {
          onSubmit(e);
        } catch (error) {
        console.error('Erro ao submeter formulário de Precatoria:', error);
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
          target: document.getElementById(`PrecatoriaForm-${precatoriaData.id}`)
        } as unknown as React.FormEvent;

        onSubmit(syntheticEvent);
      } catch (error) {
      console.error('Erro ao salvar Precatoria diretamente:', error);
      setIsSubmitting(false);
      if (onError) onError();
      }
    }
  };
  useEffect(() => {
    const el = document.querySelector('.nameFormMobile');
    if (el) {
      el.textContent = precatoriaData?.id == 0 ? 'Editar Precatoria' : 'Adicionar Precatoria';
    }
  }, [precatoriaData.id]);
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

    <div className={isMobile ? 'form-container form-container-Precatoria' : 'form-container5 form-container-Precatoria'}>

      <form className='formInputCadInc' id={`PrecatoriaForm-${precatoriaData.id}`} onSubmit={onConfirm}>
        {!isMobile && (
          <ButtonSalvarCrud isMobile={false} validationForm={validationForm} entity='Precatoria' data={precatoriaData} isSubmitting={isSubmitting} onClose={onClose} formId={`PrecatoriaForm-${precatoriaData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
          )}
          <div className='grid-container'>


            <InputInput
            type='text'
            maxLength={2048}
            id='dtdist'
            label='DtDist'
            dataForm={precatoriaData}
            className='inputIncNome'
            name='dtdist'
            value={precatoriaData.dtdist}
            onChange={onChange}
            />


            <ProcessosComboBox
            name={'processo'}
            dataForm={precatoriaData}
            value={precatoriaData.processo}
            setValue={addValorProcesso}
            label={'Processos'}
            />

            <InputInput
            type='text'
            maxLength={25}
            id='precatoriax'
            label='Precatoria'
            dataForm={precatoriaData}
            className='inputIncNome'
            name='precatoriax'
            value={precatoriaData.precatoriax}
            onChange={onChange}
            />


            <InputInput
            type='text'
            maxLength={60}
            id='deprecante'
            label='Deprecante'
            dataForm={precatoriaData}
            className='inputIncNome'
            name='deprecante'
            value={precatoriaData.deprecante}
            onChange={onChange}
            />


            <InputInput
            type='text'
            maxLength={60}
            id='deprecado'
            label='Deprecado'
            dataForm={precatoriaData}
            className='inputIncNome'
            name='deprecado'
            value={precatoriaData.deprecado}
            onChange={onChange}
            />


            <InputInput
            type='text'
            maxLength={2147483647}
            id='obs'
            label='OBS'
            dataForm={precatoriaData}
            className='inputIncNome'
            name='obs'
            value={precatoriaData.obs}
            onChange={onChange}
            />

          </div>
        </form>


        {isMobile && (
          <ButtonSalvarCrud isMobile={true} validationForm={validationForm} entity='Precatoria' data={precatoriaData} isSubmitting={isSubmitting} onClose={onClose} formId={`PrecatoriaForm-${precatoriaData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
          )}
          <DeleteButton page={'/pages/precatoria'} id={precatoriaData.id} closeModel={onClose} dadoApi={dadoApi} />
        </div>
        <div className='form-spacer'></div>
        </>
      );
    };