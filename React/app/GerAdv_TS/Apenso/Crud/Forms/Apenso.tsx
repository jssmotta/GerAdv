// Tracking: Forms.tsx.txt
'use client';
import { IApenso } from '@/app/GerAdv_TS/Apenso/Interfaces/interface.Apenso';
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
import { ApensoApi } from '../../Apis/ApiApenso';
import { useValidationsApenso } from '../../Hooks/hookApenso';
import ProcessosComboBox from '@/app/GerAdv_TS/Processos/ComboBox/Processos';
import { ProcessosApi } from '@/app/GerAdv_TS/Processos/Apis/ApiProcessos';
import InputName from '@/app/components/Inputs/InputName';
import InputInput from '@/app/components/Inputs/InputInput'
interface ApensoFormProps {
  apensoData: IApenso;
  onChange: (e: any) => void;
  onSubmit: (e: React.FormEvent) => void;
  onClose: () => void;
  onError?: () => void;
  onReload?: () => void;
  onSuccess?: (registro?: any) => void;
}

export const ApensoForm: React.FC<ApensoFormProps> = ({
  apensoData, 
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
const dadoApi = new ApensoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [isSubmitting, setIsSubmitting] = useState(false);
const initialized = useRef(false);
const validationForm = useValidationsApenso();
const [nomeProcessos, setNomeProcessos] = useState('');
const processosApi = new ProcessosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

if (getParamFromUrl('processos') > 0) {
  if (apensoData.id === 0 && apensoData.processo == 0) {
    processosApi
    .getById(getParamFromUrl('processos'))
    .then((response) => {
      setNomeProcessos(response.data.nropasta);
    })
    .catch((error) => {
      console.error(error);
    });

    apensoData.processo = getParamFromUrl('processos');
  }
}
const addValorProcesso = (e: any) => {
  if (e?.id>0)
    apensoData.processo = e.id;
  };
  const onConfirm = (e: React.FormEvent) => {
    e.preventDefault();
    if (e.stopPropagation) e.stopPropagation();

      if (!isSubmitting) {
        setIsSubmitting(true);

        try {
          onSubmit(e);
        } catch (error) {
        console.error('Erro ao submeter formulário de Apenso:', error);
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
          target: document.getElementById(`ApensoForm-${apensoData.id}`)
        } as unknown as React.FormEvent;

        onSubmit(syntheticEvent);
      } catch (error) {
      console.error('Erro ao salvar Apenso diretamente:', error);
      setIsSubmitting(false);
      if (onError) onError();
      }
    }
  };
  useEffect(() => {
    const el = document.querySelector('.nameFormMobile');
    if (el) {
      el.textContent = apensoData?.id == 0 ? 'Editar Apenso' : 'Adicionar Apenso';
    }
  }, [apensoData.id]);
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

    <div className={isMobile ? 'form-container form-container-Apenso' : 'form-container5 form-container-Apenso'}>

      <form className='formInputCadInc' id={`ApensoForm-${apensoData.id}`} onSubmit={onConfirm}>
        {!isMobile && (
          <ButtonSalvarCrud isMobile={false} validationForm={validationForm} entity='Apenso' data={apensoData} isSubmitting={isSubmitting} onClose={onClose} formId={`ApensoForm-${apensoData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
          )}
          <div className='grid-container'>


            <ProcessosComboBox
            name={'processo'}
            dataForm={apensoData}
            value={apensoData.processo}
            setValue={addValorProcesso}
            label={'Processos'}
            />

            <InputInput
            type='text'
            maxLength={25}
            id='apensox'
            label='Apenso'
            dataForm={apensoData}
            className='inputIncNome'
            name='apensox'
            value={apensoData.apensox}
            onChange={onChange}
            />


            <InputInput
            type='text'
            maxLength={25}
            id='acao'
            label='Acao'
            dataForm={apensoData}
            className='inputIncNome'
            name='acao'
            value={apensoData.acao}
            onChange={onChange}
            />


            <InputInput
            type='text'
            maxLength={2048}
            id='dtdist'
            label='DtDist'
            dataForm={apensoData}
            className='inputIncNome'
            name='dtdist'
            value={apensoData.dtdist}
            onChange={onChange}
            />


            <InputInput
            type='text'
            maxLength={2147483647}
            id='obs'
            label='OBS'
            dataForm={apensoData}
            className='inputIncNome'
            name='obs'
            value={apensoData.obs}
            onChange={onChange}
            />


            <InputInput
            type='text'
            maxLength={2048}
            id='valorcausa'
            label='ValorCausa'
            dataForm={apensoData}
            className='inputIncNome'
            name='valorcausa'
            value={apensoData.valorcausa}
            onChange={onChange}
            />

          </div>
        </form>


        {isMobile && (
          <ButtonSalvarCrud isMobile={true} validationForm={validationForm} entity='Apenso' data={apensoData} isSubmitting={isSubmitting} onClose={onClose} formId={`ApensoForm-${apensoData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
          )}
          <DeleteButton page={'/pages/apenso'} id={apensoData.id} closeModel={onClose} dadoApi={dadoApi} />
        </div>
        <div className='form-spacer'></div>
        </>
      );
    };