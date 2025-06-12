// Tracking: Forms.tsx.txt
'use client';
import { IProObservacoes } from '@/app/GerAdv_TS/ProObservacoes/Interfaces/interface.ProObservacoes';
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
import { ProObservacoesApi } from '../../Apis/ApiProObservacoes';
import { useValidationsProObservacoes } from '../../Hooks/hookProObservacoes';
import ProcessosComboBox from '@/app/GerAdv_TS/Processos/ComboBox/Processos';
import { ProcessosApi } from '@/app/GerAdv_TS/Processos/Apis/ApiProcessos';
import InputName from '@/app/components/Inputs/InputName';
import InputInput from '@/app/components/Inputs/InputInput'
interface ProObservacoesFormProps {
  proobservacoesData: IProObservacoes;
  onChange: (e: any) => void;
  onSubmit: (e: React.FormEvent) => void;
  onClose: () => void;
  onError?: () => void;
  onReload?: () => void;
  onSuccess?: (registro?: any) => void;
}

export const ProObservacoesForm: React.FC<ProObservacoesFormProps> = ({
  proobservacoesData, 
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
const dadoApi = new ProObservacoesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [isSubmitting, setIsSubmitting] = useState(false);
const initialized = useRef(false);
const validationForm = useValidationsProObservacoes();
const [nomeProcessos, setNomeProcessos] = useState('');
const processosApi = new ProcessosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

if (getParamFromUrl('processos') > 0) {
  if (proobservacoesData.id === 0 && proobservacoesData.processo == 0) {
    processosApi
    .getById(getParamFromUrl('processos'))
    .then((response) => {
      setNomeProcessos(response.data.nropasta);
    })
    .catch((error) => {
      console.error(error);
    });

    proobservacoesData.processo = getParamFromUrl('processos');
  }
}
const addValorProcesso = (e: any) => {
  if (e?.id>0)
    proobservacoesData.processo = e.id;
  };
  const onConfirm = (e: React.FormEvent) => {
    e.preventDefault();
    if (e.stopPropagation) e.stopPropagation();

      if (!isSubmitting) {
        setIsSubmitting(true);

        try {
          onSubmit(e);
        } catch (error) {
        console.error('Erro ao submeter formulário de ProObservacoes:', error);
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
          target: document.getElementById(`ProObservacoesForm-${proobservacoesData.id}`)
        } as unknown as React.FormEvent;

        onSubmit(syntheticEvent);
      } catch (error) {
      console.error('Erro ao salvar ProObservacoes diretamente:', error);
      setIsSubmitting(false);
      if (onError) onError();
      }
    }
  };
  useEffect(() => {
    const el = document.querySelector('.nameFormMobile');
    if (el) {
      el.textContent = proobservacoesData?.id == 0 ? 'Editar ProObservacoes' : 'Adicionar Pro Observacoes';
    }
  }, [proobservacoesData.id]);
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

    <div className={isMobile ? 'form-container form-container-ProObservacoes' : 'form-container5 form-container-ProObservacoes'}>

      <form className='formInputCadInc' id={`ProObservacoesForm-${proobservacoesData.id}`} onSubmit={onConfirm}>
        {!isMobile && (
          <ButtonSalvarCrud isMobile={false} validationForm={validationForm} entity='ProObservacoes' data={proobservacoesData} isSubmitting={isSubmitting} onClose={onClose} formId={`ProObservacoesForm-${proobservacoesData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
          )}
          <div className='grid-container'>

            <InputName
            type='text'
            id='nome'
            label='Nome'
            dataForm={proobservacoesData}
            className='inputIncNome'
            name='nome'
            value={proobservacoesData.nome}
            placeholder={`Informe Nome`}
            onChange={onChange}
            required
            />

            <ProcessosComboBox
            name={'processo'}
            dataForm={proobservacoesData}
            value={proobservacoesData.processo}
            setValue={addValorProcesso}
            label={'Processos'}
            />

            <InputInput
            type='text'
            maxLength={2147483647}
            id='observacoes'
            label='Observacoes'
            dataForm={proobservacoesData}
            className='inputIncNome'
            name='observacoes'
            value={proobservacoesData.observacoes}
            onChange={onChange}
            />


            <InputInput
            type='text'
            maxLength={2048}
            id='data'
            label='Data'
            dataForm={proobservacoesData}
            className='inputIncNome'
            name='data'
            value={proobservacoesData.data}
            onChange={onChange}
            />

          </div>
        </form>


        {isMobile && (
          <ButtonSalvarCrud isMobile={true} validationForm={validationForm} entity='ProObservacoes' data={proobservacoesData} isSubmitting={isSubmitting} onClose={onClose} formId={`ProObservacoesForm-${proobservacoesData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
          )}
          <DeleteButton page={'/pages/proobservacoes'} id={proobservacoesData.id} closeModel={onClose} dadoApi={dadoApi} />
        </div>
        <div className='form-spacer'></div>
        </>
      );
    };