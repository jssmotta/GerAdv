// Tracking: Forms.tsx.txt
'use client';
import { IModelosDocumentos } from '@/app/GerAdv_TS/ModelosDocumentos/Interfaces/interface.ModelosDocumentos';
import { useRouter } from 'next/navigation';
import { useEffect, useState, useRef } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudFormsBase.css';
import '@/app/styles/CrudFormsMobile.css';
import '@/app/styles/Inputs.css';
import '@/app/styles/CrudForms.css'; // [ INDEX_SIZE ]
import ButtonSalvarCrud from '@/app/components/Cruds/ButtonSalvarCrud';
import { useIsMobile } from '@/app/context/MobileContext';
import DeleteButton from '@/app/components/Cruds/DeleteButton';
import { ModelosDocumentosApi } from '../../Apis/ApiModelosDocumentos';
import { useValidationsModelosDocumentos } from '../../Hooks/hookModelosDocumentos';
import TipoModeloDocumentoComboBox from '@/app/GerAdv_TS/TipoModeloDocumento/ComboBox/TipoModeloDocumento';
import { TipoModeloDocumentoApi } from '@/app/GerAdv_TS/TipoModeloDocumento/Apis/ApiTipoModeloDocumento';
import InputName from '@/app/components/Inputs/InputName';
import InputInput from '@/app/components/Inputs/InputInput'
interface ModelosDocumentosFormProps {
  modelosdocumentosData: IModelosDocumentos;
  onChange: (e: any) => void;
  onSubmit: (e: React.FormEvent) => void;
  onClose: () => void;
  onError?: () => void;
  onReload?: () => void;
  onSuccess?: (registro?: any) => void;
}

export const ModelosDocumentosForm: React.FC<ModelosDocumentosFormProps> = ({
  modelosdocumentosData, 
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
const dadoApi = new ModelosDocumentosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [isSubmitting, setIsSubmitting] = useState(false);
const initialized = useRef(false);
const validationForm = useValidationsModelosDocumentos();
const [nomeTipoModeloDocumento, setNomeTipoModeloDocumento] = useState('');
const tipomodelodocumentoApi = new TipoModeloDocumentoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

if (getParamFromUrl('tipomodelodocumento') > 0) {
  if (modelosdocumentosData.id === 0 && modelosdocumentosData.tipomodelodocumento == 0) {
    tipomodelodocumentoApi
    .getById(getParamFromUrl('tipomodelodocumento'))
    .then((response) => {
      setNomeTipoModeloDocumento(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

    modelosdocumentosData.tipomodelodocumento = getParamFromUrl('tipomodelodocumento');
  }
}
const addValorTipoModeloDocumento = (e: any) => {
  if (e?.id>0)
    modelosdocumentosData.tipomodelodocumento = e.id;
  };
  const onConfirm = (e: React.FormEvent) => {
    e.preventDefault();
    if (e.stopPropagation) e.stopPropagation();

      if (!isSubmitting) {
        setIsSubmitting(true);

        try {
          onSubmit(e);
        } catch (error) {
        console.error('Erro ao submeter formulário de ModelosDocumentos:', error);
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
          target: document.getElementById(`ModelosDocumentosForm-${modelosdocumentosData.id}`)
        } as unknown as React.FormEvent;

        onSubmit(syntheticEvent);
      } catch (error) {
      console.error('Erro ao salvar ModelosDocumentos diretamente:', error);
      setIsSubmitting(false);
      if (onError) onError();
      }
    }
  };
  useEffect(() => {
    const el = document.querySelector('.nameFormMobile');
    if (el) {
      el.textContent = modelosdocumentosData?.id == 0 ? 'Editar ModelosDocumentos' : 'Adicionar Modelos Documentos';
    }
  }, [modelosdocumentosData.id]);
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

    <div className={isMobile ? 'form-container form-container-ModelosDocumentos' : 'form-container form-container-ModelosDocumentos'}>

      <form className='formInputCadInc' id={`ModelosDocumentosForm-${modelosdocumentosData.id}`} onSubmit={onConfirm}>
        {!isMobile && (
          <ButtonSalvarCrud isMobile={false} validationForm={validationForm} entity='ModelosDocumentos' data={modelosdocumentosData} isSubmitting={isSubmitting} onClose={onClose} formId={`ModelosDocumentosForm-${modelosdocumentosData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
          )}
          <div className='grid-container'>

            <InputName
            type='text'
            id='nome'
            label='Nome'
            dataForm={modelosdocumentosData}
            className='inputIncNome'
            name='nome'
            value={modelosdocumentosData.nome}
            placeholder={`Informe Nome`}
            onChange={onChange}
            required
            />

            <InputInput
            type='text'
            maxLength={2147483647}
            id='remuneracao'
            label='Remuneracao'
            dataForm={modelosdocumentosData}
            className='inputIncNome'
            name='remuneracao'
            value={modelosdocumentosData.remuneracao}
            onChange={onChange}
            />


            <InputInput
            type='text'
            maxLength={2147483647}
            id='assinatura'
            label='Assinatura'
            dataForm={modelosdocumentosData}
            className='inputIncNome'
            name='assinatura'
            value={modelosdocumentosData.assinatura}
            onChange={onChange}
            />


            <InputInput
            type='text'
            maxLength={2147483647}
            id='header'
            label='Header'
            dataForm={modelosdocumentosData}
            className='inputIncNome'
            name='header'
            value={modelosdocumentosData.header}
            onChange={onChange}
            />


            <InputInput
            type='text'
            maxLength={2147483647}
            id='footer'
            label='Footer'
            dataForm={modelosdocumentosData}
            className='inputIncNome'
            name='footer'
            value={modelosdocumentosData.footer}
            onChange={onChange}
            />


            <InputInput
            type='text'
            maxLength={2147483647}
            id='extra1'
            label='Extra1'
            dataForm={modelosdocumentosData}
            className='inputIncNome'
            name='extra1'
            value={modelosdocumentosData.extra1}
            onChange={onChange}
            />


            <InputInput
            type='text'
            maxLength={2147483647}
            id='extra2'
            label='Extra2'
            dataForm={modelosdocumentosData}
            className='inputIncNome'
            name='extra2'
            value={modelosdocumentosData.extra2}
            onChange={onChange}
            />


            <InputInput
            type='text'
            maxLength={2147483647}
            id='extra3'
            label='Extra3'
            dataForm={modelosdocumentosData}
            className='inputIncNome'
            name='extra3'
            value={modelosdocumentosData.extra3}
            onChange={onChange}
            />


            <InputInput
            type='text'
            maxLength={2147483647}
            id='outorgante'
            label='Outorgante'
            dataForm={modelosdocumentosData}
            className='inputIncNome'
            name='outorgante'
            value={modelosdocumentosData.outorgante}
            onChange={onChange}
            />


            <InputInput
            type='text'
            maxLength={2147483647}
            id='outorgados'
            label='Outorgados'
            dataForm={modelosdocumentosData}
            className='inputIncNome'
            name='outorgados'
            value={modelosdocumentosData.outorgados}
            onChange={onChange}
            />

          </div><div className='grid-container'>
            <InputInput
            type='text'
            maxLength={2147483647}
            id='poderes'
            label='Poderes'
            dataForm={modelosdocumentosData}
            className='inputIncNome'
            name='poderes'
            value={modelosdocumentosData.poderes}
            onChange={onChange}
            />


            <InputInput
            type='text'
            maxLength={2147483647}
            id='objeto'
            label='Objeto'
            dataForm={modelosdocumentosData}
            className='inputIncNome'
            name='objeto'
            value={modelosdocumentosData.objeto}
            onChange={onChange}
            />


            <InputInput
            type='text'
            maxLength={2000}
            id='titulo'
            label='Titulo'
            dataForm={modelosdocumentosData}
            className='inputIncNome'
            name='titulo'
            value={modelosdocumentosData.titulo}
            onChange={onChange}
            />


            <InputInput
            type='text'
            maxLength={2147483647}
            id='testemunhas'
            label='Testemunhas'
            dataForm={modelosdocumentosData}
            className='inputIncNome'
            name='testemunhas'
            value={modelosdocumentosData.testemunhas}
            onChange={onChange}
            />


            <TipoModeloDocumentoComboBox
            name={'tipomodelodocumento'}
            dataForm={modelosdocumentosData}
            value={modelosdocumentosData.tipomodelodocumento}
            setValue={addValorTipoModeloDocumento}
            label={'Tipo Modelo Documento'}
            />

            <InputInput
            type='text'
            maxLength={2147483647}
            id='css'
            label='CSS'
            dataForm={modelosdocumentosData}
            className='inputIncNome'
            name='css'
            value={modelosdocumentosData.css}
            onChange={onChange}
            />

          </div>
        </form>


        {isMobile && (
          <ButtonSalvarCrud isMobile={true} validationForm={validationForm} entity='ModelosDocumentos' data={modelosdocumentosData} isSubmitting={isSubmitting} onClose={onClose} formId={`ModelosDocumentosForm-${modelosdocumentosData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
          )}
          <DeleteButton page={'/pages/modelosdocumentos'} id={modelosdocumentosData.id} closeModel={onClose} dadoApi={dadoApi} />
        </div>
        <div className='form-spacer'></div>
        </>
      );
    };