// Tracking: Forms.tsx.txt
'use client';
import { IAreasJustica } from '@/app/GerAdv_TS/AreasJustica/Interfaces/interface.AreasJustica';
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
import { AreasJusticaApi } from '../../Apis/ApiAreasJustica';
import { useValidationsAreasJustica } from '../../Hooks/hookAreasJustica';
import AreaComboBox from '@/app/GerAdv_TS/Area/ComboBox/Area';
import JusticaComboBox from '@/app/GerAdv_TS/Justica/ComboBox/Justica';
import { AreaApi } from '@/app/GerAdv_TS/Area/Apis/ApiArea';
import { JusticaApi } from '@/app/GerAdv_TS/Justica/Apis/ApiJustica';
import InputName from '@/app/components/Inputs/InputName';
interface AreasJusticaFormProps {
  areasjusticaData: IAreasJustica;
  onChange: (e: any) => void;
  onSubmit: (e: React.FormEvent) => void;
  onClose: () => void;
  onError?: () => void;
  onReload?: () => void;
  onSuccess?: (registro?: any) => void;
}

export const AreasJusticaForm: React.FC<AreasJusticaFormProps> = ({
  areasjusticaData, 
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
const dadoApi = new AreasJusticaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [isSubmitting, setIsSubmitting] = useState(false);
const initialized = useRef(false);
const validationForm = useValidationsAreasJustica();
const [nomeArea, setNomeArea] = useState('');
const areaApi = new AreaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeJustica, setNomeJustica] = useState('');
const justicaApi = new JusticaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

if (getParamFromUrl('area') > 0) {
  if (areasjusticaData.id === 0 && areasjusticaData.area == 0) {
    areaApi
    .getById(getParamFromUrl('area'))
    .then((response) => {
      setNomeArea(response.data.descricao);
    })
    .catch((error) => {
      console.error(error);
    });

    areasjusticaData.area = getParamFromUrl('area');
  }
}

if (getParamFromUrl('justica') > 0) {
  if (areasjusticaData.id === 0 && areasjusticaData.justica == 0) {
    justicaApi
    .getById(getParamFromUrl('justica'))
    .then((response) => {
      setNomeJustica(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

    areasjusticaData.justica = getParamFromUrl('justica');
  }
}
const addValorArea = (e: any) => {
  if (e?.id>0)
    areasjusticaData.area = e.id;
  };
  const addValorJustica = (e: any) => {
    if (e?.id>0)
      areasjusticaData.justica = e.id;
    };
    const onConfirm = (e: React.FormEvent) => {
      e.preventDefault();
      if (e.stopPropagation) e.stopPropagation();

        if (!isSubmitting) {
          setIsSubmitting(true);

          try {
            onSubmit(e);
          } catch (error) {
          console.error('Erro ao submeter formulário de AreasJustica:', error);
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
            target: document.getElementById(`AreasJusticaForm-${areasjusticaData.id}`)
          } as unknown as React.FormEvent;

          onSubmit(syntheticEvent);
        } catch (error) {
        console.error('Erro ao salvar AreasJustica diretamente:', error);
        setIsSubmitting(false);
        if (onError) onError();
        }
      }
    };
    useEffect(() => {
      const el = document.querySelector('.nameFormMobile');
      if (el) {
        el.textContent = areasjusticaData?.id == 0 ? 'Editar AreasJustica' : 'Adicionar Areas Justica';
      }
    }, [areasjusticaData.id]);
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

      <div className={isMobile ? 'form-container form-container-AreasJustica' : 'form-container5 form-container-AreasJustica'}>

        <form className='formInputCadInc' id={`AreasJusticaForm-${areasjusticaData.id}`} onSubmit={onConfirm}>
          {!isMobile && (
            <ButtonSalvarCrud isMobile={false} validationForm={validationForm} entity='AreasJustica' data={areasjusticaData} isSubmitting={isSubmitting} onClose={onClose} formId={`AreasJusticaForm-${areasjusticaData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
            )}
            <div className='grid-container'>


              <AreaComboBox
              name={'area'}
              dataForm={areasjusticaData}
              value={areasjusticaData.area}
              setValue={addValorArea}
              label={'Area'}
              />

              <JusticaComboBox
              name={'justica'}
              dataForm={areasjusticaData}
              value={areasjusticaData.justica}
              setValue={addValorJustica}
              label={'Justica'}
              />
            </div>
          </form>


          {isMobile && (
            <ButtonSalvarCrud isMobile={true} validationForm={validationForm} entity='AreasJustica' data={areasjusticaData} isSubmitting={isSubmitting} onClose={onClose} formId={`AreasJusticaForm-${areasjusticaData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
            )}
            <DeleteButton page={'/pages/areasjustica'} id={areasjusticaData.id} closeModel={onClose} dadoApi={dadoApi} />
          </div>
          <div className='form-spacer'></div>
          </>
        );
      };