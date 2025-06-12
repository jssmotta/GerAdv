// Tracking: Forms.tsx.txt
'use client';
import { ITipoRecurso } from '@/app/GerAdv_TS/TipoRecurso/Interfaces/interface.TipoRecurso';
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
import { TipoRecursoApi } from '../../Apis/ApiTipoRecurso';
import { useValidationsTipoRecurso } from '../../Hooks/hookTipoRecurso';
import JusticaComboBox from '@/app/GerAdv_TS/Justica/ComboBox/Justica';
import AreaComboBox from '@/app/GerAdv_TS/Area/ComboBox/Area';
import { JusticaApi } from '@/app/GerAdv_TS/Justica/Apis/ApiJustica';
import { AreaApi } from '@/app/GerAdv_TS/Area/Apis/ApiArea';
import InputDescription from '@/app/components/Inputs/InputDescription';
interface TipoRecursoFormProps {
  tiporecursoData: ITipoRecurso;
  onChange: (e: any) => void;
  onSubmit: (e: React.FormEvent) => void;
  onClose: () => void;
  onError?: () => void;
  onReload?: () => void;
  onSuccess?: (registro?: any) => void;
}

export const TipoRecursoForm: React.FC<TipoRecursoFormProps> = ({
  tiporecursoData, 
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
const dadoApi = new TipoRecursoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [isSubmitting, setIsSubmitting] = useState(false);
const initialized = useRef(false);
const validationForm = useValidationsTipoRecurso();
const [nomeJustica, setNomeJustica] = useState('');
const justicaApi = new JusticaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeArea, setNomeArea] = useState('');
const areaApi = new AreaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

if (getParamFromUrl('justica') > 0) {
  if (tiporecursoData.id === 0 && tiporecursoData.justica == 0) {
    justicaApi
    .getById(getParamFromUrl('justica'))
    .then((response) => {
      setNomeJustica(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

    tiporecursoData.justica = getParamFromUrl('justica');
  }
}

if (getParamFromUrl('area') > 0) {
  if (tiporecursoData.id === 0 && tiporecursoData.area == 0) {
    areaApi
    .getById(getParamFromUrl('area'))
    .then((response) => {
      setNomeArea(response.data.descricao);
    })
    .catch((error) => {
      console.error(error);
    });

    tiporecursoData.area = getParamFromUrl('area');
  }
}
const addValorJustica = (e: any) => {
  if (e?.id>0)
    tiporecursoData.justica = e.id;
  };
  const addValorArea = (e: any) => {
    if (e?.id>0)
      tiporecursoData.area = e.id;
    };
    const onConfirm = (e: React.FormEvent) => {
      e.preventDefault();
      if (e.stopPropagation) e.stopPropagation();

        if (!isSubmitting) {
          setIsSubmitting(true);

          try {
            onSubmit(e);
          } catch (error) {
          console.error('Erro ao submeter formulário de TipoRecurso:', error);
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
            target: document.getElementById(`TipoRecursoForm-${tiporecursoData.id}`)
          } as unknown as React.FormEvent;

          onSubmit(syntheticEvent);
        } catch (error) {
        console.error('Erro ao salvar TipoRecurso diretamente:', error);
        setIsSubmitting(false);
        if (onError) onError();
        }
      }
    };
    useEffect(() => {
      const el = document.querySelector('.nameFormMobile');
      if (el) {
        el.textContent = tiporecursoData?.id == 0 ? 'Editar TipoRecurso' : 'Adicionar Tipo Recurso';
      }
    }, [tiporecursoData.id]);
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

      <div className={isMobile ? 'form-container form-container-TipoRecurso' : 'form-container5 form-container-TipoRecurso'}>

        <form className='formInputCadInc' id={`TipoRecursoForm-${tiporecursoData.id}`} onSubmit={onConfirm}>
          {!isMobile && (
            <ButtonSalvarCrud isMobile={false} validationForm={validationForm} entity='TipoRecurso' data={tiporecursoData} isSubmitting={isSubmitting} onClose={onClose} formId={`TipoRecursoForm-${tiporecursoData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
            )}
            <div className='grid-container'>

              <InputDescription
              type='text'
              id='descricao'
              label='tipo recurso'
              dataForm={tiporecursoData}
              className='inputIncNome'
              name='descricao'
              value={tiporecursoData.descricao}
              placeholder={`Digite nome tipo recurso`}
              onChange={onChange}
              required
              disabled={tiporecursoData.id > 0}
              />

              <JusticaComboBox
              name={'justica'}
              dataForm={tiporecursoData}
              value={tiporecursoData.justica}
              setValue={addValorJustica}
              label={'Justica'}
              />

              <AreaComboBox
              name={'area'}
              dataForm={tiporecursoData}
              value={tiporecursoData.area}
              setValue={addValorArea}
              label={'Area'}
              />
            </div>
          </form>


          {isMobile && (
            <ButtonSalvarCrud isMobile={true} validationForm={validationForm} entity='TipoRecurso' data={tiporecursoData} isSubmitting={isSubmitting} onClose={onClose} formId={`TipoRecursoForm-${tiporecursoData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
            )}
            <DeleteButton page={'/pages/tiporecurso'} id={tiporecursoData.id} closeModel={onClose} dadoApi={dadoApi} />
          </div>
          <div className='form-spacer'></div>
          </>
        );
      };