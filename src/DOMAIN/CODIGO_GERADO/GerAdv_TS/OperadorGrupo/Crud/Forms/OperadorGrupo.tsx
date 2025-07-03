// Tracking: Forms.tsx.txt
'use client';
import { IOperadorGrupo } from '@/app/GerAdv_TS/OperadorGrupo/Interfaces/interface.OperadorGrupo';
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
import { OperadorGrupoApi } from '../../Apis/ApiOperadorGrupo';
import { useValidationsOperadorGrupo } from '../../Hooks/hookOperadorGrupo';
import OperadorComboBox from '@/app/GerAdv_TS/Operador/ComboBox/Operador';
import { OperadorApi } from '@/app/GerAdv_TS/Operador/Apis/ApiOperador';
import InputName from '@/app/components/Inputs/InputName';
import InputInput from '@/app/components/Inputs/InputInput'
import InputCheckbox from '@/app/components/Inputs/InputCheckbox';
interface OperadorGrupoFormProps {
  operadorgrupoData: IOperadorGrupo;
  onChange: (e: any) => void;
  onSubmit: (e: React.FormEvent) => void;
  onClose: () => void;
  onError?: () => void;
  onReload?: () => void;
  onSuccess?: (registro?: any) => void;
}

export const OperadorGrupoForm: React.FC<OperadorGrupoFormProps> = ({
  operadorgrupoData, 
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
const dadoApi = new OperadorGrupoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [isSubmitting, setIsSubmitting] = useState(false);
const initialized = useRef(false);
const validationForm = useValidationsOperadorGrupo();
const [nomeOperador, setNomeOperador] = useState('');
const operadorApi = new OperadorApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

if (getParamFromUrl('operador') > 0) {
  if (operadorgrupoData.id === 0 && operadorgrupoData.operador == 0) {
    operadorApi
    .getById(getParamFromUrl('operador'))
    .then((response) => {
      setNomeOperador(response.data.rnome);
    })
    .catch((error) => {
      console.error(error);
    });

    operadorgrupoData.operador = getParamFromUrl('operador');
  }
}
const addValorOperador = (e: any) => {
  if (e?.id>0)
    operadorgrupoData.operador = e.id;
  };
  const onConfirm = (e: React.FormEvent) => {
    e.preventDefault();
    if (e.stopPropagation) e.stopPropagation();

      if (!isSubmitting) {
        setIsSubmitting(true);

        try {
          onSubmit(e);
        } catch (error) {
        console.error('Erro ao submeter formulário de OperadorGrupo:', error);
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
          target: document.getElementById(`OperadorGrupoForm-${operadorgrupoData.id}`)
        } as unknown as React.FormEvent;

        onSubmit(syntheticEvent);
      } catch (error) {
      console.error('Erro ao salvar OperadorGrupo diretamente:', error);
      setIsSubmitting(false);
      if (onError) onError();
      }
    }
  };
  useEffect(() => {
    const el = document.querySelector('.nameFormMobile');
    if (el) {
      el.textContent = operadorgrupoData?.id == 0 ? 'Editar OperadorGrupo' : 'Adicionar Operador Grupo';
    }
  }, [operadorgrupoData.id]);
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

    <div className={isMobile ? 'form-container form-container-OperadorGrupo' : 'form-container5 form-container-OperadorGrupo'}>

      <form className='formInputCadInc' id={`OperadorGrupoForm-${operadorgrupoData.id}`} onSubmit={onConfirm}>
        {!isMobile && (
          <ButtonSalvarCrud isMobile={false} validationForm={validationForm} entity='OperadorGrupo' data={operadorgrupoData} isSubmitting={isSubmitting} onClose={onClose} formId={`OperadorGrupoForm-${operadorgrupoData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
          )}
          <div className='grid-container'>


            <OperadorComboBox
            name={'operador'}
            dataForm={operadorgrupoData}
            value={operadorgrupoData.operador}
            setValue={addValorOperador}
            label={'Operador'}
            />

            <InputInput
            type='text'
            maxLength={2048}
            id='grupo'
            label='Grupo'
            dataForm={operadorgrupoData}
            className='inputIncNome'
            name='grupo'
            value={operadorgrupoData.grupo}
            onChange={onChange}
            />

            <InputCheckbox dataForm={operadorgrupoData} label='Inativo' name='inativo' checked={operadorgrupoData.inativo} onChange={onChange} />
          </div>
        </form>


        {isMobile && (
          <ButtonSalvarCrud isMobile={true} validationForm={validationForm} entity='OperadorGrupo' data={operadorgrupoData} isSubmitting={isSubmitting} onClose={onClose} formId={`OperadorGrupoForm-${operadorgrupoData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
          )}
          <DeleteButton page={'/pages/operadorgrupo'} id={operadorgrupoData.id} closeModel={onClose} dadoApi={dadoApi} />
        </div>
        <div className='form-spacer'></div>
        </>
      );
    };