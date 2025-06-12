// Tracking: Forms.tsx.txt
'use client';
import { IAcao } from '@/app/GerAdv_TS/Acao/Interfaces/interface.Acao';
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
import { AcaoApi } from '../../Apis/ApiAcao';
import { useValidationsAcao } from '../../Hooks/hookAcao';
import JusticaComboBox from '@/app/GerAdv_TS/Justica/ComboBox/Justica';
import AreaComboBox from '@/app/GerAdv_TS/Area/ComboBox/Area';
import { JusticaApi } from '@/app/GerAdv_TS/Justica/Apis/ApiJustica';
import { AreaApi } from '@/app/GerAdv_TS/Area/Apis/ApiArea';
import InputDescription from '@/app/components/Inputs/InputDescription';
interface AcaoFormProps {
  acaoData: IAcao;
  onChange: (e: any) => void;
  onSubmit: (e: React.FormEvent) => void;
  onClose: () => void;
  onError?: () => void;
  onReload?: () => void;
  onSuccess?: (registro?: any) => void;
}

export const AcaoForm: React.FC<AcaoFormProps> = ({
  acaoData, 
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
const dadoApi = new AcaoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [isSubmitting, setIsSubmitting] = useState(false);
const initialized = useRef(false);
const validationForm = useValidationsAcao();
const [nomeJustica, setNomeJustica] = useState('');
const justicaApi = new JusticaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeArea, setNomeArea] = useState('');
const areaApi = new AreaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

if (getParamFromUrl('justica') > 0) {
  if (acaoData.id === 0 && acaoData.justica == 0) {
    justicaApi
    .getById(getParamFromUrl('justica'))
    .then((response) => {
      setNomeJustica(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

    acaoData.justica = getParamFromUrl('justica');
  }
}

if (getParamFromUrl('area') > 0) {
  if (acaoData.id === 0 && acaoData.area == 0) {
    areaApi
    .getById(getParamFromUrl('area'))
    .then((response) => {
      setNomeArea(response.data.descricao);
    })
    .catch((error) => {
      console.error(error);
    });

    acaoData.area = getParamFromUrl('area');
  }
}
const addValorJustica = (e: any) => {
  if (e?.id>0)
    acaoData.justica = e.id;
  };
  const addValorArea = (e: any) => {
    if (e?.id>0)
      acaoData.area = e.id;
    };
    const onConfirm = (e: React.FormEvent) => {
      e.preventDefault();
      if (e.stopPropagation) e.stopPropagation();

        if (!isSubmitting) {
          setIsSubmitting(true);

          try {
            onSubmit(e);
          } catch (error) {
          console.error('Erro ao submeter formulário de Acao:', error);
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
            target: document.getElementById(`AcaoForm-${acaoData.id}`)
          } as unknown as React.FormEvent;

          onSubmit(syntheticEvent);
        } catch (error) {
        console.error('Erro ao salvar Acao diretamente:', error);
        setIsSubmitting(false);
        if (onError) onError();
        }
      }
    };
    useEffect(() => {
      const el = document.querySelector('.nameFormMobile');
      if (el) {
        el.textContent = acaoData?.id == 0 ? 'Editar Acao' : 'Adicionar Acao';
      }
    }, [acaoData.id]);
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

      <div className={isMobile ? 'form-container form-container-Acao' : 'form-container5 form-container-Acao'}>

        <form className='formInputCadInc' id={`AcaoForm-${acaoData.id}`} onSubmit={onConfirm}>
          {!isMobile && (
            <ButtonSalvarCrud isMobile={false} validationForm={validationForm} entity='Acao' data={acaoData} isSubmitting={isSubmitting} onClose={onClose} formId={`AcaoForm-${acaoData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
            )}
            <div className='grid-container'>

              <InputDescription
              type='text'
              id='descricao'
              label='acao'
              dataForm={acaoData}
              className='inputIncNome'
              name='descricao'
              value={acaoData.descricao}
              placeholder={`Digite nome acao`}
              onChange={onChange}
              required
              disabled={acaoData.id > 0}
              />

              <JusticaComboBox
              name={'justica'}
              dataForm={acaoData}
              value={acaoData.justica}
              setValue={addValorJustica}
              label={'Justica'}
              />

              <AreaComboBox
              name={'area'}
              dataForm={acaoData}
              value={acaoData.area}
              setValue={addValorArea}
              label={'Area'}
              />
            </div>
          </form>


          {isMobile && (
            <ButtonSalvarCrud isMobile={true} validationForm={validationForm} entity='Acao' data={acaoData} isSubmitting={isSubmitting} onClose={onClose} formId={`AcaoForm-${acaoData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
            )}
            <DeleteButton page={'/pages/acao'} id={acaoData.id} closeModel={onClose} dadoApi={dadoApi} />
          </div>
          <div className='form-spacer'></div>
          </>
        );
      };