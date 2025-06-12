// Tracking: Forms.tsx.txt
'use client';
import { IAnexamentoRegistros } from '@/app/GerAdv_TS/AnexamentoRegistros/Interfaces/interface.AnexamentoRegistros';
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
import { AnexamentoRegistrosApi } from '../../Apis/ApiAnexamentoRegistros';
import { useValidationsAnexamentoRegistros } from '../../Hooks/hookAnexamentoRegistros';
import ClientesComboBox from '@/app/GerAdv_TS/Clientes/ComboBox/Clientes';
import { ClientesApi } from '@/app/GerAdv_TS/Clientes/Apis/ApiClientes';
import InputName from '@/app/components/Inputs/InputName';
import InputInput from '@/app/components/Inputs/InputInput'
interface AnexamentoRegistrosFormProps {
  anexamentoregistrosData: IAnexamentoRegistros;
  onChange: (e: any) => void;
  onSubmit: (e: React.FormEvent) => void;
  onClose: () => void;
  onError?: () => void;
  onReload?: () => void;
  onSuccess?: (registro?: any) => void;
}

export const AnexamentoRegistrosForm: React.FC<AnexamentoRegistrosFormProps> = ({
  anexamentoregistrosData, 
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
const dadoApi = new AnexamentoRegistrosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [isSubmitting, setIsSubmitting] = useState(false);
const initialized = useRef(false);
const validationForm = useValidationsAnexamentoRegistros();
const [nomeClientes, setNomeClientes] = useState('');
const clientesApi = new ClientesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

if (getParamFromUrl('clientes') > 0) {
  if (anexamentoregistrosData.id === 0 && anexamentoregistrosData.cliente == 0) {
    clientesApi
    .getById(getParamFromUrl('clientes'))
    .then((response) => {
      setNomeClientes(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

    anexamentoregistrosData.cliente = getParamFromUrl('clientes');
  }
}
const addValorCliente = (e: any) => {
  if (e?.id>0)
    anexamentoregistrosData.cliente = e.id;
  };
  const onConfirm = (e: React.FormEvent) => {
    e.preventDefault();
    if (e.stopPropagation) e.stopPropagation();

      if (!isSubmitting) {
        setIsSubmitting(true);

        try {
          onSubmit(e);
        } catch (error) {
        console.error('Erro ao submeter formulário de AnexamentoRegistros:', error);
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
          target: document.getElementById(`AnexamentoRegistrosForm-${anexamentoregistrosData.id}`)
        } as unknown as React.FormEvent;

        onSubmit(syntheticEvent);
      } catch (error) {
      console.error('Erro ao salvar AnexamentoRegistros diretamente:', error);
      setIsSubmitting(false);
      if (onError) onError();
      }
    }
  };
  useEffect(() => {
    const el = document.querySelector('.nameFormMobile');
    if (el) {
      el.textContent = anexamentoregistrosData?.id == 0 ? 'Editar AnexamentoRegistros' : 'Adicionar Anexamento Registros';
    }
  }, [anexamentoregistrosData.id]);
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

    <div className={isMobile ? 'form-container form-container-AnexamentoRegistros' : 'form-container5 form-container-AnexamentoRegistros'}>

      <form className='formInputCadInc' id={`AnexamentoRegistrosForm-${anexamentoregistrosData.id}`} onSubmit={onConfirm}>
        {!isMobile && (
          <ButtonSalvarCrud isMobile={false} validationForm={validationForm} entity='AnexamentoRegistros' data={anexamentoregistrosData} isSubmitting={isSubmitting} onClose={onClose} formId={`AnexamentoRegistrosForm-${anexamentoregistrosData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
          )}
          <div className='grid-container'>


            <ClientesComboBox
            name={'cliente'}
            dataForm={anexamentoregistrosData}
            value={anexamentoregistrosData.cliente}
            setValue={addValorCliente}
            label={'Clientes'}
            />

            <InputInput
            type='text'
            maxLength={100}
            id='guidreg'
            label='GUIDReg'
            dataForm={anexamentoregistrosData}
            className='inputIncNome'
            name='guidreg'
            value={anexamentoregistrosData.guidreg}
            onChange={onChange}
            />


            <InputInput
            type='text'
            maxLength={2048}
            id='codigoreg'
            label='CodigoReg'
            dataForm={anexamentoregistrosData}
            className='inputIncNome'
            name='codigoreg'
            value={anexamentoregistrosData.codigoreg}
            onChange={onChange}
            />


            <InputInput
            type='text'
            maxLength={2048}
            id='idreg'
            label='IDReg'
            dataForm={anexamentoregistrosData}
            className='inputIncNome'
            name='idreg'
            value={anexamentoregistrosData.idreg}
            onChange={onChange}
            />


            <InputInput
            type='text'
            maxLength={2048}
            id='data'
            label='Data'
            dataForm={anexamentoregistrosData}
            className='inputIncNome'
            name='data'
            value={anexamentoregistrosData.data}
            onChange={onChange}
            />

          </div>
        </form>


        {isMobile && (
          <ButtonSalvarCrud isMobile={true} validationForm={validationForm} entity='AnexamentoRegistros' data={anexamentoregistrosData} isSubmitting={isSubmitting} onClose={onClose} formId={`AnexamentoRegistrosForm-${anexamentoregistrosData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
          )}
          <DeleteButton page={'/pages/anexamentoregistros'} id={anexamentoregistrosData.id} closeModel={onClose} dadoApi={dadoApi} />
        </div>
        <div className='form-spacer'></div>
        </>
      );
    };