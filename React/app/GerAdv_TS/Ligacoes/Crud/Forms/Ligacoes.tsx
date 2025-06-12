// Tracking: Forms.tsx.txt
'use client';
import { ILigacoes } from '@/app/GerAdv_TS/Ligacoes/Interfaces/interface.Ligacoes';
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
import { LigacoesApi } from '../../Apis/ApiLigacoes';
import { useValidationsLigacoes } from '../../Hooks/hookLigacoes';
import ClientesComboBox from '@/app/GerAdv_TS/Clientes/ComboBox/Clientes';
import RamalComboBox from '@/app/GerAdv_TS/Ramal/ComboBox/Ramal';
import ProcessosComboBox from '@/app/GerAdv_TS/Processos/ComboBox/Processos';
import { ClientesApi } from '@/app/GerAdv_TS/Clientes/Apis/ApiClientes';
import { RamalApi } from '@/app/GerAdv_TS/Ramal/Apis/ApiRamal';
import { ProcessosApi } from '@/app/GerAdv_TS/Processos/Apis/ApiProcessos';
import InputName from '@/app/components/Inputs/InputName';
import InputInput from '@/app/components/Inputs/InputInput'
import InputCheckbox from '@/app/components/Inputs/InputCheckbox';
interface LigacoesFormProps {
  ligacoesData: ILigacoes;
  onChange: (e: any) => void;
  onSubmit: (e: React.FormEvent) => void;
  onClose: () => void;
  onError?: () => void;
  onReload?: () => void;
  onSuccess?: (registro?: any) => void;
}

export const LigacoesForm: React.FC<LigacoesFormProps> = ({
  ligacoesData, 
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
const dadoApi = new LigacoesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [isSubmitting, setIsSubmitting] = useState(false);
const initialized = useRef(false);
const validationForm = useValidationsLigacoes();
const [nomeClientes, setNomeClientes] = useState('');
const clientesApi = new ClientesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeRamal, setNomeRamal] = useState('');
const ramalApi = new RamalApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeProcessos, setNomeProcessos] = useState('');
const processosApi = new ProcessosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

if (getParamFromUrl('clientes') > 0) {
  if (ligacoesData.id === 0 && ligacoesData.cliente == 0) {
    clientesApi
    .getById(getParamFromUrl('clientes'))
    .then((response) => {
      setNomeClientes(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

    ligacoesData.cliente = getParamFromUrl('clientes');
  }
}

if (getParamFromUrl('ramal') > 0) {
  if (ligacoesData.id === 0 && ligacoesData.ramal == 0) {
    ramalApi
    .getById(getParamFromUrl('ramal'))
    .then((response) => {
      setNomeRamal(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

    ligacoesData.ramal = getParamFromUrl('ramal');
  }
}

if (getParamFromUrl('processos') > 0) {
  if (ligacoesData.id === 0 && ligacoesData.processo == 0) {
    processosApi
    .getById(getParamFromUrl('processos'))
    .then((response) => {
      setNomeProcessos(response.data.nropasta);
    })
    .catch((error) => {
      console.error(error);
    });

    ligacoesData.processo = getParamFromUrl('processos');
  }
}
const addValorCliente = (e: any) => {
  if (e?.id>0)
    ligacoesData.cliente = e.id;
  };
  const addValorRamal = (e: any) => {
    if (e?.id>0)
      ligacoesData.ramal = e.id;
    };
    const addValorProcesso = (e: any) => {
      if (e?.id>0)
        ligacoesData.processo = e.id;
      };
      const onConfirm = (e: React.FormEvent) => {
        e.preventDefault();
        if (e.stopPropagation) e.stopPropagation();

          if (!isSubmitting) {
            setIsSubmitting(true);

            try {
              onSubmit(e);
            } catch (error) {
            console.error('Erro ao submeter formulário de Ligacoes:', error);
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
              target: document.getElementById(`LigacoesForm-${ligacoesData.id}`)
            } as unknown as React.FormEvent;

            onSubmit(syntheticEvent);
          } catch (error) {
          console.error('Erro ao salvar Ligacoes diretamente:', error);
          setIsSubmitting(false);
          if (onError) onError();
          }
        }
      };
      useEffect(() => {
        const el = document.querySelector('.nameFormMobile');
        if (el) {
          el.textContent = ligacoesData?.id == 0 ? 'Editar Ligacoes' : 'Adicionar Ligacoes';
        }
      }, [ligacoesData.id]);
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

        <div className={isMobile ? 'form-container form-container-Ligacoes' : 'form-container form-container-Ligacoes'}>

          <form className='formInputCadInc' id={`LigacoesForm-${ligacoesData.id}`} onSubmit={onConfirm}>
            {!isMobile && (
              <ButtonSalvarCrud isMobile={false} validationForm={validationForm} entity='Ligacoes' data={ligacoesData} isSubmitting={isSubmitting} onClose={onClose} formId={`LigacoesForm-${ligacoesData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
              )}
              <div className='grid-container'>

                <InputName
                type='text'
                id='nome'
                label='Nome'
                dataForm={ligacoesData}
                className='inputIncNome'
                name='nome'
                value={ligacoesData.nome}
                placeholder={`Informe Nome`}
                onChange={onChange}
                required
                />

                <InputInput
                type='text'
                maxLength={200}
                id='assunto'
                label='Assunto'
                dataForm={ligacoesData}
                className='inputIncNome'
                name='assunto'
                value={ligacoesData.assunto}
                onChange={onChange}
                />


                <InputInput
                type='text'
                maxLength={2048}
                id='ageclienteavisado'
                label='AgeClienteAvisado'
                dataForm={ligacoesData}
                className='inputIncNome'
                name='ageclienteavisado'
                value={ligacoesData.ageclienteavisado}
                onChange={onChange}
                />

                <InputCheckbox dataForm={ligacoesData} label='Celular' name='celular' checked={ligacoesData.celular} onChange={onChange} />

                <ClientesComboBox
                name={'cliente'}
                dataForm={ligacoesData}
                value={ligacoesData.cliente}
                setValue={addValorCliente}
                label={'Clientes'}
                />

                <InputInput
                type='text'
                maxLength={200}
                id='contato'
                label='Contato'
                dataForm={ligacoesData}
                className='inputIncNome'
                name='contato'
                value={ligacoesData.contato}
                onChange={onChange}
                />


                <InputInput
                type='text'
                maxLength={2048}
                id='datarealizada'
                label='DataRealizada'
                dataForm={ligacoesData}
                className='inputIncNome'
                name='datarealizada'
                value={ligacoesData.datarealizada}
                onChange={onChange}
                />


                <InputInput
                type='text'
                maxLength={2048}
                id='quemid'
                label='QuemID'
                dataForm={ligacoesData}
                className='inputIncNome'
                name='quemid'
                value={ligacoesData.quemid}
                onChange={onChange}
                />


                <InputInput
                type='text'
                maxLength={2048}
                id='telefonista'
                label='Telefonista'
                dataForm={ligacoesData}
                className='inputIncNome'
                name='telefonista'
                value={ligacoesData.telefonista}
                onChange={onChange}
                />


                <InputInput
                type='text'
                maxLength={2048}
                id='ultimoaviso'
                label='UltimoAviso'
                dataForm={ligacoesData}
                className='inputIncNome'
                name='ultimoaviso'
                value={ligacoesData.ultimoaviso}
                onChange={onChange}
                />

              </div><div className='grid-container'>
                <InputInput
                type='text'
                maxLength={2048}
                id='horafinal'
                label='HoraFinal'
                dataForm={ligacoesData}
                className='inputIncNome'
                name='horafinal'
                value={ligacoesData.horafinal}
                onChange={onChange}
                />


                <InputInput
                type='text'
                maxLength={2048}
                id='quemcodigo'
                label='QuemCodigo'
                dataForm={ligacoesData}
                className='inputIncNome'
                name='quemcodigo'
                value={ligacoesData.quemcodigo}
                onChange={onChange}
                />


                <InputInput
                type='text'
                maxLength={2048}
                id='solicitante'
                label='Solicitante'
                dataForm={ligacoesData}
                className='inputIncNome'
                name='solicitante'
                value={ligacoesData.solicitante}
                onChange={onChange}
                />


                <InputInput
                type='text'
                maxLength={100}
                id='para'
                label='Para'
                dataForm={ligacoesData}
                className='inputIncNome'
                name='para'
                value={ligacoesData.para}
                onChange={onChange}
                />


                <InputInput
                type='text'
                maxLength={2147483647}
                id='fone'
                label='Fone'
                dataForm={ligacoesData}
                className='inputIncNome'
                name='fone'
                value={ligacoesData.fone}
                onChange={onChange}
                />


                <RamalComboBox
                name={'ramal'}
                dataForm={ligacoesData}
                value={ligacoesData.ramal}
                setValue={addValorRamal}
                label={'Ramal'}
                />
                <InputCheckbox dataForm={ligacoesData} label='Particular' name='particular' checked={ligacoesData.particular} onChange={onChange} />
                <InputCheckbox dataForm={ligacoesData} label='Realizada' name='realizada' checked={ligacoesData.realizada} onChange={onChange} />

                <InputInput
                type='text'
                maxLength={2147483647}
                id='status'
                label='Status'
                dataForm={ligacoesData}
                className='inputIncNome'
                name='status'
                value={ligacoesData.status}
                onChange={onChange}
                />


                <InputInput
                type='text'
                maxLength={2048}
                id='data'
                label='Data'
                dataForm={ligacoesData}
                className='inputIncNome'
                name='data'
                value={ligacoesData.data}
                onChange={onChange}
                />

              </div><div className='grid-container'>
                <InputInput
                type='text'
                maxLength={2048}
                id='hora'
                label='Hora'
                dataForm={ligacoesData}
                className='inputIncNome'
                name='hora'
                value={ligacoesData.hora}
                onChange={onChange}
                />

                <InputCheckbox dataForm={ligacoesData} label='Urgente' name='urgente' checked={ligacoesData.urgente} onChange={onChange} />

                <InputInput
                type='text'
                maxLength={255}
                id='ligarpara'
                label='LigarPara'
                dataForm={ligacoesData}
                className='inputIncNome'
                name='ligarpara'
                value={ligacoesData.ligarpara}
                onChange={onChange}
                />


                <ProcessosComboBox
                name={'processo'}
                dataForm={ligacoesData}
                value={ligacoesData.processo}
                setValue={addValorProcesso}
                label={'Processos'}
                />
                <InputCheckbox dataForm={ligacoesData} label='StartScreen' name='startscreen' checked={ligacoesData.startscreen} onChange={onChange} />

                <InputInput
                type='text'
                maxLength={2048}
                id='emotion'
                label='Emotion'
                dataForm={ligacoesData}
                className='inputIncNome'
                name='emotion'
                value={ligacoesData.emotion}
                onChange={onChange}
                />

              </div>
            </form>


            {isMobile && (
              <ButtonSalvarCrud isMobile={true} validationForm={validationForm} entity='Ligacoes' data={ligacoesData} isSubmitting={isSubmitting} onClose={onClose} formId={`LigacoesForm-${ligacoesData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
              )}
              <DeleteButton page={'/pages/ligacoes'} id={ligacoesData.id} closeModel={onClose} dadoApi={dadoApi} />
            </div>
            <div className='form-spacer'></div>
            </>
          );
        };