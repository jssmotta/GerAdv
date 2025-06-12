// Tracking: Forms.tsx.txt
'use client';
import { ICidade } from '@/app/GerAdv_TS/Cidade/Interfaces/interface.Cidade';
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
import { CidadeApi } from '../../Apis/ApiCidade';
import { useValidationsCidade } from '../../Hooks/hookCidade';
import UFComboBox from '@/app/GerAdv_TS/UF/ComboBox/UF';
import { UFApi } from '@/app/GerAdv_TS/UF/Apis/ApiUF';
import InputName from '@/app/components/Inputs/InputName';
import InputInput from '@/app/components/Inputs/InputInput'
import InputCheckbox from '@/app/components/Inputs/InputCheckbox';
interface CidadeFormProps {
  cidadeData: ICidade;
  onChange: (e: any) => void;
  onSubmit: (e: React.FormEvent) => void;
  onClose: () => void;
  onError?: () => void;
  onReload?: () => void;
  onSuccess?: (registro?: any) => void;
}

export const CidadeForm: React.FC<CidadeFormProps> = ({
  cidadeData, 
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
const dadoApi = new CidadeApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [isSubmitting, setIsSubmitting] = useState(false);
const initialized = useRef(false);
const validationForm = useValidationsCidade();
const [nomeUF, setNomeUF] = useState('');
const ufApi = new UFApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

if (getParamFromUrl('uf') > 0) {
  if (cidadeData.id === 0 && cidadeData.uf == 0) {
    ufApi
    .getById(getParamFromUrl('uf'))
    .then((response) => {
      setNomeUF(response.data.d);
    })
    .catch((error) => {
      console.error(error);
    });

    cidadeData.uf = getParamFromUrl('uf');
  }
}
const addValorUF = (e: any) => {
  if (e?.id>0)
    cidadeData.uf = e.id;
  };
  const onConfirm = (e: React.FormEvent) => {
    e.preventDefault();
    if (e.stopPropagation) e.stopPropagation();

      if (!isSubmitting) {
        setIsSubmitting(true);

        try {
          onSubmit(e);
        } catch (error) {
        console.error('Erro ao submeter formulário de Cidade:', error);
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
          target: document.getElementById(`CidadeForm-${cidadeData.id}`)
        } as unknown as React.FormEvent;

        onSubmit(syntheticEvent);
      } catch (error) {
      console.error('Erro ao salvar Cidade diretamente:', error);
      setIsSubmitting(false);
      if (onError) onError();
      }
    }
  };
  useEffect(() => {
    const el = document.querySelector('.nameFormMobile');
    if (el) {
      el.textContent = cidadeData?.id == 0 ? 'Editar Cidade' : 'Adicionar Cidade';
    }
  }, [cidadeData.id]);
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

    <div className={isMobile ? 'form-container form-container-Cidade' : 'form-container5 form-container-Cidade'}>

      <form className='formInputCadInc' id={`CidadeForm-${cidadeData.id}`} onSubmit={onConfirm}>
        {!isMobile && (
          <ButtonSalvarCrud isMobile={false} validationForm={validationForm} entity='Cidade' data={cidadeData} isSubmitting={isSubmitting} onClose={onClose} formId={`CidadeForm-${cidadeData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
          )}
          <div className='grid-container'>

            <InputName
            type='text'
            id='nome'
            label='Nome'
            dataForm={cidadeData}
            className='inputIncNome'
            name='nome'
            value={cidadeData.nome}
            placeholder={`Informe Nome`}
            onChange={onChange}
            required
            />

            <InputInput
            type='text'
            maxLength={10}
            id='ddd'
            label='DDD'
            dataForm={cidadeData}
            className='inputIncNome'
            name='ddd'
            value={cidadeData.ddd}
            onChange={onChange}
            />

            <InputCheckbox dataForm={cidadeData} label='Top' name='top' checked={cidadeData.top} onChange={onChange} />
            <InputCheckbox dataForm={cidadeData} label='Comarca' name='comarca' checked={cidadeData.comarca} onChange={onChange} />
            <InputCheckbox dataForm={cidadeData} label='Capital' name='capital' checked={cidadeData.capital} onChange={onChange} />

            <UFComboBox
            name={'uf'}
            dataForm={cidadeData}
            value={cidadeData.uf}
            setValue={addValorUF}
            label={'UF'}
            />

            <InputInput
            type='text'
            maxLength={10}
            id='sigla'
            label='Sigla'
            dataForm={cidadeData}
            className='inputIncNome'
            name='sigla'
            value={cidadeData.sigla}
            onChange={onChange}
            />

          </div>
        </form>


        {isMobile && (
          <ButtonSalvarCrud isMobile={true} validationForm={validationForm} entity='Cidade' data={cidadeData} isSubmitting={isSubmitting} onClose={onClose} formId={`CidadeForm-${cidadeData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
          )}
          <DeleteButton page={'/pages/cidade'} id={cidadeData.id} closeModel={onClose} dadoApi={dadoApi} />
        </div>
        <div className='form-spacer'></div>
        </>
      );
    };