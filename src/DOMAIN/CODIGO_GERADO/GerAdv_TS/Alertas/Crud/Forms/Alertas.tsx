// Tracking: Forms.tsx.txt
'use client';
import { IAlertas } from '@/app/GerAdv_TS/Alertas/Interfaces/interface.Alertas';
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
import { AlertasApi } from '../../Apis/ApiAlertas';
import { useValidationsAlertas } from '../../Hooks/hookAlertas';
import OperadorComboBox from '@/app/GerAdv_TS/Operador/ComboBox/Operador';
import { OperadorApi } from '@/app/GerAdv_TS/Operador/Apis/ApiOperador';
import InputName from '@/app/components/Inputs/InputName';
import InputInput from '@/app/components/Inputs/InputInput'
interface AlertasFormProps {
  alertasData: IAlertas;
  onChange: (e: any) => void;
  onSubmit: (e: React.FormEvent) => void;
  onClose: () => void;
  onError?: () => void;
  onReload?: () => void;
  onSuccess?: (registro?: any) => void;
}

export const AlertasForm: React.FC<AlertasFormProps> = ({
  alertasData, 
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
const dadoApi = new AlertasApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [isSubmitting, setIsSubmitting] = useState(false);
const initialized = useRef(false);
const validationForm = useValidationsAlertas();
const [nomeOperador, setNomeOperador] = useState('');
const operadorApi = new OperadorApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

if (getParamFromUrl('operador') > 0) {
  if (alertasData.id === 0 && alertasData.operador == 0) {
    operadorApi
    .getById(getParamFromUrl('operador'))
    .then((response) => {
      setNomeOperador(response.data.rnome);
    })
    .catch((error) => {
      console.error(error);
    });

    alertasData.operador = getParamFromUrl('operador');
  }
}
const addValorOperador = (e: any) => {
  if (e?.id>0)
    alertasData.operador = e.id;
  };
  const onConfirm = (e: React.FormEvent) => {
    e.preventDefault();
    if (e.stopPropagation) e.stopPropagation();

      if (!isSubmitting) {
        setIsSubmitting(true);

        try {
          onSubmit(e);
        } catch (error) {
        console.error('Erro ao submeter formulário de Alertas:', error);
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
          target: document.getElementById(`AlertasForm-${alertasData.id}`)
        } as unknown as React.FormEvent;

        onSubmit(syntheticEvent);
      } catch (error) {
      console.error('Erro ao salvar Alertas diretamente:', error);
      setIsSubmitting(false);
      if (onError) onError();
      }
    }
  };
  useEffect(() => {
    const el = document.querySelector('.nameFormMobile');
    if (el) {
      el.textContent = alertasData?.id == 0 ? 'Editar Alertas' : 'Adicionar Alertas';
    }
  }, [alertasData.id]);
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

    <div className={isMobile ? 'form-container form-container-Alertas' : 'form-container5 form-container-Alertas'}>

      <form className='formInputCadInc' id={`AlertasForm-${alertasData.id}`} onSubmit={onConfirm}>
        {!isMobile && (
          <ButtonSalvarCrud isMobile={false} validationForm={validationForm} entity='Alertas' data={alertasData} isSubmitting={isSubmitting} onClose={onClose} formId={`AlertasForm-${alertasData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
          )}
          <div className='grid-container'>

            <InputName
            type='text'
            id='nome'
            label='Nome'
            dataForm={alertasData}
            className='inputIncNome'
            name='nome'
            value={alertasData.nome}
            placeholder={`Informe Nome`}
            onChange={onChange}
            required
            />

            <InputInput
            type='text'
            maxLength={2048}
            id='data'
            label='Data'
            dataForm={alertasData}
            className='inputIncNome'
            name='data'
            value={alertasData.data}
            onChange={onChange}
            />


            <OperadorComboBox
            name={'operador'}
            dataForm={alertasData}
            value={alertasData.operador}
            setValue={addValorOperador}
            label={'Operador'}
            />

            <InputInput
            type='text'
            maxLength={2048}
            id='dataate'
            label='DataAte'
            dataForm={alertasData}
            className='inputIncNome'
            name='dataate'
            value={alertasData.dataate}
            onChange={onChange}
            />

          </div>
        </form>


        {isMobile && (
          <ButtonSalvarCrud isMobile={true} validationForm={validationForm} entity='Alertas' data={alertasData} isSubmitting={isSubmitting} onClose={onClose} formId={`AlertasForm-${alertasData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
          )}
          <DeleteButton page={'/pages/alertas'} id={alertasData.id} closeModel={onClose} dadoApi={dadoApi} />
        </div>
        <div className='form-spacer'></div>
        </>
      );
    };