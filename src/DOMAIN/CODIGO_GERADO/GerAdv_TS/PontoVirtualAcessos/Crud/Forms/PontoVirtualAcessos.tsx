// Tracking: Forms.tsx.txt
'use client';
import { IPontoVirtualAcessos } from '@/app/GerAdv_TS/PontoVirtualAcessos/Interfaces/interface.PontoVirtualAcessos';
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
import { PontoVirtualAcessosApi } from '../../Apis/ApiPontoVirtualAcessos';
import { useValidationsPontoVirtualAcessos } from '../../Hooks/hookPontoVirtualAcessos';
import OperadorComboBox from '@/app/GerAdv_TS/Operador/ComboBox/Operador';
import { OperadorApi } from '@/app/GerAdv_TS/Operador/Apis/ApiOperador';
import InputName from '@/app/components/Inputs/InputName';
import InputInput from '@/app/components/Inputs/InputInput'
import InputCheckbox from '@/app/components/Inputs/InputCheckbox';
interface PontoVirtualAcessosFormProps {
  pontovirtualacessosData: IPontoVirtualAcessos;
  onChange: (e: any) => void;
  onSubmit: (e: React.FormEvent) => void;
  onClose: () => void;
  onError?: () => void;
  onReload?: () => void;
  onSuccess?: (registro?: any) => void;
}

export const PontoVirtualAcessosForm: React.FC<PontoVirtualAcessosFormProps> = ({
  pontovirtualacessosData, 
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
const dadoApi = new PontoVirtualAcessosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [isSubmitting, setIsSubmitting] = useState(false);
const initialized = useRef(false);
const validationForm = useValidationsPontoVirtualAcessos();
const [nomeOperador, setNomeOperador] = useState('');
const operadorApi = new OperadorApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

if (getParamFromUrl('operador') > 0) {
  if (pontovirtualacessosData.id === 0 && pontovirtualacessosData.operador == 0) {
    operadorApi
    .getById(getParamFromUrl('operador'))
    .then((response) => {
      setNomeOperador(response.data.rnome);
    })
    .catch((error) => {
      console.error(error);
    });

    pontovirtualacessosData.operador = getParamFromUrl('operador');
  }
}
const addValorOperador = (e: any) => {
  if (e?.id>0)
    pontovirtualacessosData.operador = e.id;
  };
  const onConfirm = (e: React.FormEvent) => {
    e.preventDefault();
    if (e.stopPropagation) e.stopPropagation();

      if (!isSubmitting) {
        setIsSubmitting(true);

        try {
          onSubmit(e);
        } catch (error) {
        console.error('Erro ao submeter formulário de PontoVirtualAcessos:', error);
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
          target: document.getElementById(`PontoVirtualAcessosForm-${pontovirtualacessosData.id}`)
        } as unknown as React.FormEvent;

        onSubmit(syntheticEvent);
      } catch (error) {
      console.error('Erro ao salvar PontoVirtualAcessos diretamente:', error);
      setIsSubmitting(false);
      if (onError) onError();
      }
    }
  };
  useEffect(() => {
    const el = document.querySelector('.nameFormMobile');
    if (el) {
      el.textContent = pontovirtualacessosData?.id == 0 ? 'Editar PontoVirtualAcessos' : 'Adicionar Ponto Virtual Acessos';
    }
  }, [pontovirtualacessosData.id]);
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

    <div className={isMobile ? 'form-container form-container-PontoVirtualAcessos' : 'form-container5 form-container-PontoVirtualAcessos'}>

      <form className='formInputCadInc' id={`PontoVirtualAcessosForm-${pontovirtualacessosData.id}`} onSubmit={onConfirm}>
        {!isMobile && (
          <ButtonSalvarCrud isMobile={false} validationForm={validationForm} entity='PontoVirtualAcessos' data={pontovirtualacessosData} isSubmitting={isSubmitting} onClose={onClose} formId={`PontoVirtualAcessosForm-${pontovirtualacessosData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
          )}
          <div className='grid-container'>


            <OperadorComboBox
            name={'operador'}
            dataForm={pontovirtualacessosData}
            value={pontovirtualacessosData.operador}
            setValue={addValorOperador}
            label={'Operador'}
            />

            <InputInput
            type='text'
            maxLength={2048}
            id='datahora'
            label='DataHora'
            dataForm={pontovirtualacessosData}
            className='inputIncNome'
            name='datahora'
            value={pontovirtualacessosData.datahora}
            onChange={onChange}
            />

            <InputCheckbox dataForm={pontovirtualacessosData} label='Tipo' name='tipo' checked={pontovirtualacessosData.tipo} onChange={onChange} />

            <InputInput
            type='text'
            maxLength={150}
            id='origem'
            label='Origem'
            dataForm={pontovirtualacessosData}
            className='inputIncNome'
            name='origem'
            value={pontovirtualacessosData.origem}
            onChange={onChange}
            />

          </div>
        </form>


        {isMobile && (
          <ButtonSalvarCrud isMobile={true} validationForm={validationForm} entity='PontoVirtualAcessos' data={pontovirtualacessosData} isSubmitting={isSubmitting} onClose={onClose} formId={`PontoVirtualAcessosForm-${pontovirtualacessosData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
          )}
          <DeleteButton page={'/pages/pontovirtualacessos'} id={pontovirtualacessosData.id} closeModel={onClose} dadoApi={dadoApi} />
        </div>
        <div className='form-spacer'></div>
        </>
      );
    };