// Tracking: Forms.tsx.txt
'use client';
import { IOperadorGruposAgenda } from '@/app/GerAdv_TS/OperadorGruposAgenda/Interfaces/interface.OperadorGruposAgenda';
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
import { OperadorGruposAgendaApi } from '../../Apis/ApiOperadorGruposAgenda';
import { useValidationsOperadorGruposAgenda } from '../../Hooks/hookOperadorGruposAgenda';
import OperadorComboBox from '@/app/GerAdv_TS/Operador/ComboBox/Operador';
import { OperadorApi } from '@/app/GerAdv_TS/Operador/Apis/ApiOperador';
import InputName from '@/app/components/Inputs/InputName';
import InputInput from '@/app/components/Inputs/InputInput'
interface OperadorGruposAgendaFormProps {
  operadorgruposagendaData: IOperadorGruposAgenda;
  onChange: (e: any) => void;
  onSubmit: (e: React.FormEvent) => void;
  onClose: () => void;
  onError?: () => void;
  onReload?: () => void;
  onSuccess?: (registro?: any) => void;
}

export const OperadorGruposAgendaForm: React.FC<OperadorGruposAgendaFormProps> = ({
  operadorgruposagendaData, 
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
const dadoApi = new OperadorGruposAgendaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [isSubmitting, setIsSubmitting] = useState(false);
const initialized = useRef(false);
const validationForm = useValidationsOperadorGruposAgenda();
const [nomeOperador, setNomeOperador] = useState('');
const operadorApi = new OperadorApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

if (getParamFromUrl('operador') > 0) {
  if (operadorgruposagendaData.id === 0 && operadorgruposagendaData.operador == 0) {
    operadorApi
    .getById(getParamFromUrl('operador'))
    .then((response) => {
      setNomeOperador(response.data.rnome);
    })
    .catch((error) => {
      console.error(error);
    });

    operadorgruposagendaData.operador = getParamFromUrl('operador');
  }
}
const addValorOperador = (e: any) => {
  if (e?.id>0)
    operadorgruposagendaData.operador = e.id;
  };
  const onConfirm = (e: React.FormEvent) => {
    e.preventDefault();
    if (e.stopPropagation) e.stopPropagation();

      if (!isSubmitting) {
        setIsSubmitting(true);

        try {
          onSubmit(e);
        } catch (error) {
        console.error('Erro ao submeter formulário de OperadorGruposAgenda:', error);
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
          target: document.getElementById(`OperadorGruposAgendaForm-${operadorgruposagendaData.id}`)
        } as unknown as React.FormEvent;

        onSubmit(syntheticEvent);
      } catch (error) {
      console.error('Erro ao salvar OperadorGruposAgenda diretamente:', error);
      setIsSubmitting(false);
      if (onError) onError();
      }
    }
  };
  useEffect(() => {
    const el = document.querySelector('.nameFormMobile');
    if (el) {
      el.textContent = operadorgruposagendaData?.id == 0 ? 'Editar OperadorGruposAgenda' : 'Adicionar Operador Grupos Agenda';
    }
  }, [operadorgruposagendaData.id]);
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

    <div className={isMobile ? 'form-container form-container-OperadorGruposAgenda' : 'form-container5 form-container-OperadorGruposAgenda'}>

      <form className='formInputCadInc' id={`OperadorGruposAgendaForm-${operadorgruposagendaData.id}`} onSubmit={onConfirm}>
        {!isMobile && (
          <ButtonSalvarCrud isMobile={false} validationForm={validationForm} entity='OperadorGruposAgenda' data={operadorgruposagendaData} isSubmitting={isSubmitting} onClose={onClose} formId={`OperadorGruposAgendaForm-${operadorgruposagendaData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
          )}
          <div className='grid-container'>

            <InputName
            type='text'
            id='nome'
            label='Nome'
            dataForm={operadorgruposagendaData}
            className='inputIncNome'
            name='nome'
            value={operadorgruposagendaData.nome}
            placeholder={`Informe Nome`}
            onChange={onChange}
            required
            />

            <InputInput
            type='text'
            maxLength={2147483647}
            id='sqlwhere'
            label='SQLWhere'
            dataForm={operadorgruposagendaData}
            className='inputIncNome'
            name='sqlwhere'
            value={operadorgruposagendaData.sqlwhere}
            onChange={onChange}
            />


            <OperadorComboBox
            name={'operador'}
            dataForm={operadorgruposagendaData}
            value={operadorgruposagendaData.operador}
            setValue={addValorOperador}
            label={'Operador'}
            />
          </div>
        </form>


        {isMobile && (
          <ButtonSalvarCrud isMobile={true} validationForm={validationForm} entity='OperadorGruposAgenda' data={operadorgruposagendaData} isSubmitting={isSubmitting} onClose={onClose} formId={`OperadorGruposAgendaForm-${operadorgruposagendaData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
          )}
          <DeleteButton page={'/pages/operadorgruposagenda'} id={operadorgruposagendaData.id} closeModel={onClose} dadoApi={dadoApi} />
        </div>
        <div className='form-spacer'></div>
        </>
      );
    };