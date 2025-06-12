// Tracking: Forms.tsx.txt
'use client';
import { IGUTAtividadesMatriz } from '@/app/GerAdv_TS/GUTAtividadesMatriz/Interfaces/interface.GUTAtividadesMatriz';
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
import { GUTAtividadesMatrizApi } from '../../Apis/ApiGUTAtividadesMatriz';
import { useValidationsGUTAtividadesMatriz } from '../../Hooks/hookGUTAtividadesMatriz';
import GUTMatrizComboBox from '@/app/GerAdv_TS/GUTMatriz/ComboBox/GUTMatriz';
import GUTAtividadesComboBox from '@/app/GerAdv_TS/GUTAtividades/ComboBox/GUTAtividades';
import { GUTMatrizApi } from '@/app/GerAdv_TS/GUTMatriz/Apis/ApiGUTMatriz';
import { GUTAtividadesApi } from '@/app/GerAdv_TS/GUTAtividades/Apis/ApiGUTAtividades';
import InputName from '@/app/components/Inputs/InputName';
interface GUTAtividadesMatrizFormProps {
  gutatividadesmatrizData: IGUTAtividadesMatriz;
  onChange: (e: any) => void;
  onSubmit: (e: React.FormEvent) => void;
  onClose: () => void;
  onError?: () => void;
  onReload?: () => void;
  onSuccess?: (registro?: any) => void;
}

export const GUTAtividadesMatrizForm: React.FC<GUTAtividadesMatrizFormProps> = ({
  gutatividadesmatrizData, 
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
const dadoApi = new GUTAtividadesMatrizApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [isSubmitting, setIsSubmitting] = useState(false);
const initialized = useRef(false);
const validationForm = useValidationsGUTAtividadesMatriz();
const [nomeGUTMatriz, setNomeGUTMatriz] = useState('');
const gutmatrizApi = new GUTMatrizApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeGUTAtividades, setNomeGUTAtividades] = useState('');
const gutatividadesApi = new GUTAtividadesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

if (getParamFromUrl('gutmatriz') > 0) {
  if (gutatividadesmatrizData.id === 0 && gutatividadesmatrizData.gutmatriz == 0) {
    gutmatrizApi
    .getById(getParamFromUrl('gutmatriz'))
    .then((response) => {
      setNomeGUTMatriz(response.data.descricao);
    })
    .catch((error) => {
      console.error(error);
    });

    gutatividadesmatrizData.gutmatriz = getParamFromUrl('gutmatriz');
  }
}

if (getParamFromUrl('gutatividades') > 0) {
  if (gutatividadesmatrizData.id === 0 && gutatividadesmatrizData.gutatividade == 0) {
    gutatividadesApi
    .getById(getParamFromUrl('gutatividades'))
    .then((response) => {
      setNomeGUTAtividades(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

    gutatividadesmatrizData.gutatividade = getParamFromUrl('gutatividades');
  }
}
const addValorGUTMatriz = (e: any) => {
  if (e?.id>0)
    gutatividadesmatrizData.gutmatriz = e.id;
  };
  const addValorGUTAtividade = (e: any) => {
    if (e?.id>0)
      gutatividadesmatrizData.gutatividade = e.id;
    };
    const onConfirm = (e: React.FormEvent) => {
      e.preventDefault();
      if (e.stopPropagation) e.stopPropagation();

        if (!isSubmitting) {
          setIsSubmitting(true);

          try {
            onSubmit(e);
          } catch (error) {
          console.error('Erro ao submeter formulário de GUTAtividadesMatriz:', error);
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
            target: document.getElementById(`GUTAtividadesMatrizForm-${gutatividadesmatrizData.id}`)
          } as unknown as React.FormEvent;

          onSubmit(syntheticEvent);
        } catch (error) {
        console.error('Erro ao salvar GUTAtividadesMatriz diretamente:', error);
        setIsSubmitting(false);
        if (onError) onError();
        }
      }
    };
    useEffect(() => {
      const el = document.querySelector('.nameFormMobile');
      if (el) {
        el.textContent = gutatividadesmatrizData?.id == 0 ? 'Editar GUTAtividadesMatriz' : 'Adicionar G U T Atividades Matriz';
      }
    }, [gutatividadesmatrizData.id]);
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

      <div className={isMobile ? 'form-container form-container-GUTAtividadesMatriz' : 'form-container5 form-container-GUTAtividadesMatriz'}>

        <form className='formInputCadInc' id={`GUTAtividadesMatrizForm-${gutatividadesmatrizData.id}`} onSubmit={onConfirm}>
          {!isMobile && (
            <ButtonSalvarCrud isMobile={false} validationForm={validationForm} entity='GUTAtividadesMatriz' data={gutatividadesmatrizData} isSubmitting={isSubmitting} onClose={onClose} formId={`GUTAtividadesMatrizForm-${gutatividadesmatrizData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
            )}
            <div className='grid-container'>


              <GUTMatrizComboBox
              name={'gutmatriz'}
              dataForm={gutatividadesmatrizData}
              value={gutatividadesmatrizData.gutmatriz}
              setValue={addValorGUTMatriz}
              label={'G U T Matriz'}
              />

              <GUTAtividadesComboBox
              name={'gutatividade'}
              dataForm={gutatividadesmatrizData}
              value={gutatividadesmatrizData.gutatividade}
              setValue={addValorGUTAtividade}
              label={'G U T Atividades'}
              />
            </div>
          </form>


          {isMobile && (
            <ButtonSalvarCrud isMobile={true} validationForm={validationForm} entity='GUTAtividadesMatriz' data={gutatividadesmatrizData} isSubmitting={isSubmitting} onClose={onClose} formId={`GUTAtividadesMatrizForm-${gutatividadesmatrizData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
            )}
            <DeleteButton page={'/pages/gutatividadesmatriz'} id={gutatividadesmatrizData.id} closeModel={onClose} dadoApi={dadoApi} />
          </div>
          <div className='form-spacer'></div>
          </>
        );
      };