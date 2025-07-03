// Tracking: Forms.tsx.txt
'use client';
import { IContatoCRM } from '@/app/GerAdv_TS/ContatoCRM/Interfaces/interface.ContatoCRM';
import { useRouter } from 'next/navigation';
import React, { useEffect, useState, useRef } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudFormsBase.css';
import '@/app/styles/CrudFormsMobile.css';
import '@/app/styles/CrudForms.css'; // [ INDEX_SIZE ]
import ButtonSalvarCrud from '@/app/components/Cruds/ButtonSalvarCrud';
import { useIsMobile } from '@/app/context/MobileContext';
import DeleteButton from '@/app/components/Cruds/DeleteButton';
import { ContatoCRMApi } from '../../Apis/ApiContatoCRM';
import { useValidationsContatoCRM } from '../../Hooks/hookContatoCRM';
import OperadorComboBox from '@/app/GerAdv_TS/Operador/ComboBox/Operador';
import ClientesComboBox from '@/app/GerAdv_TS/Clientes/ComboBox/Clientes';
import ProcessosComboBox from '@/app/GerAdv_TS/Processos/ComboBox/Processos';
import TipoContatoCRMComboBox from '@/app/GerAdv_TS/TipoContatoCRM/ComboBox/TipoContatoCRM';
import { OperadorApi } from '@/app/GerAdv_TS/Operador/Apis/ApiOperador';
import { ClientesApi } from '@/app/GerAdv_TS/Clientes/Apis/ApiClientes';
import { ProcessosApi } from '@/app/GerAdv_TS/Processos/Apis/ApiProcessos';
import { TipoContatoCRMApi } from '@/app/GerAdv_TS/TipoContatoCRM/Apis/ApiTipoContatoCRM';
import InputName from '@/app/components/Inputs/InputName';
import InputInput from '@/app/components/Inputs/InputInput'
import InputCheckbox from '@/app/components/Inputs/InputCheckbox';
interface ContatoCRMFormProps {
  contatocrmData: IContatoCRM;
  onChange: (e: any) => void;
  onSubmit: (e: React.FormEvent) => void;
  onClose: () => void;
  onError?: () => void;
  onReload?: () => void;
  onSuccess?: (registro?: any) => void;
}

export const ContatoCRMForm: React.FC<ContatoCRMFormProps> = ({
  contatocrmData, 
  onChange, 
  onSubmit, 
  onClose, 
  onError, 
  onReload, 
  onSuccess, 
}) => {
const router = useRouter();
const { systemContext } = useSystemContext();
const isMobile = useIsMobile();
const dadoApi = new ContatoCRMApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [isSubmitting, setIsSubmitting] = useState(false);
const initialized = useRef(false);
const validationForm = useValidationsContatoCRM();
const [nomeOperador, setNomeOperador] = useState('');
const operadorApi = new OperadorApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeClientes, setNomeClientes] = useState('');
const clientesApi = new ClientesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeProcessos, setNomeProcessos] = useState('');
const processosApi = new ProcessosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeTipoContatoCRM, setNomeTipoContatoCRM] = useState('');
const tipocontatocrmApi = new TipoContatoCRMApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

if (getParamFromUrl('operador') > 0) {
  if (contatocrmData.id === 0 && contatocrmData.operador == 0) {
    operadorApi
    .getById(getParamFromUrl('operador'))
    .then((response) => {
      setNomeOperador(response.data.rnome);
    })
    .catch((error) => {
      console.error(error);
    });

    contatocrmData.operador = getParamFromUrl('operador');
  }
}

if (getParamFromUrl('clientes') > 0) {
  if (contatocrmData.id === 0 && contatocrmData.cliente == 0) {
    clientesApi
    .getById(getParamFromUrl('clientes'))
    .then((response) => {
      setNomeClientes(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

    contatocrmData.cliente = getParamFromUrl('clientes');
  }
}

if (getParamFromUrl('processos') > 0) {
  if (contatocrmData.id === 0 && contatocrmData.processo == 0) {
    processosApi
    .getById(getParamFromUrl('processos'))
    .then((response) => {
      setNomeProcessos(response.data.nropasta);
    })
    .catch((error) => {
      console.error(error);
    });

    contatocrmData.processo = getParamFromUrl('processos');
  }
}

if (getParamFromUrl('tipocontatocrm') > 0) {
  if (contatocrmData.id === 0 && contatocrmData.tipocontatocrm == 0) {
    tipocontatocrmApi
    .getById(getParamFromUrl('tipocontatocrm'))
    .then((response) => {
      setNomeTipoContatoCRM(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

    contatocrmData.tipocontatocrm = getParamFromUrl('tipocontatocrm');
  }
}
const addValorOperador = (e: any) => {
  if (e?.id>0)
    contatocrmData.operador = e.id;
  };
  const addValorCliente = (e: any) => {
    if (e?.id>0)
      contatocrmData.cliente = e.id;
    };
    const addValorProcesso = (e: any) => {
      if (e?.id>0)
        contatocrmData.processo = e.id;
      };
      const addValorTipoContatoCRM = (e: any) => {
        if (e?.id>0)
          contatocrmData.tipocontatocrm = e.id;
        };
        const onConfirm = (e: React.FormEvent) => {
          e.preventDefault();
          if (e.stopPropagation) e.stopPropagation();

            if (!isSubmitting) {
              setIsSubmitting(true);

              try {
                onSubmit(e);
              } catch (error) {
              console.error('Erro ao submeter formulário de ContatoCRM:', error);
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
                target: document.getElementById(`ContatoCRMForm-${contatocrmData.id}`)
              } as unknown as React.FormEvent;

              onSubmit(syntheticEvent);
            } catch (error) {
            console.error('Erro ao salvar ContatoCRM diretamente:', error);
            setIsSubmitting(false);
            if (onError) onError();
            }
          }
        };
        useEffect(() => {
          const el = document.querySelector('.nameFormMobile');
          if (el) {
            el.textContent = contatocrmData?.id == 0 ? 'Editar ContatoCRM' : 'Adicionar Contato C R M';
          }
        }, [contatocrmData.id]);
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

          <div className={isMobile ? 'form-container form-container-ContatoCRM' : 'form-container form-container-ContatoCRM'}>

            <form className='formInputCadInc' id={`ContatoCRMForm-${contatocrmData.id}`} onSubmit={onConfirm}>
              {!isMobile && (
                <ButtonSalvarCrud isMobile={false} validationForm={validationForm} entity='ContatoCRM' data={contatocrmData} isSubmitting={isSubmitting} onClose={onClose} formId={`ContatoCRMForm-${contatocrmData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
                )}
                <div className='grid-container'>


                  <InputInput
                  type='text'
                  maxLength={2048}
                  id='ageclienteavisado'
                  label='AgeClienteAvisado'
                  dataForm={contatocrmData}
                  className='inputIncNome'
                  name='ageclienteavisado'
                  value={contatocrmData.ageclienteavisado}
                  onChange={onChange}
                  />


                  <InputInput
                  type='text'
                  maxLength={2048}
                  id='docsviarecebimento'
                  label='DocsViaRecebimento'
                  dataForm={contatocrmData}
                  className='inputIncNome'
                  name='docsviarecebimento'
                  value={contatocrmData.docsviarecebimento}
                  onChange={onChange}
                  />

                  <InputCheckbox dataForm={contatocrmData} label='NaoPublicavel' name='naopublicavel' checked={contatocrmData.naopublicavel} onChange={onChange} />
                  <InputCheckbox dataForm={contatocrmData} label='Notificar' name='notificar' checked={contatocrmData.notificar} onChange={onChange} />
                  <InputCheckbox dataForm={contatocrmData} label='Ocultar' name='ocultar' checked={contatocrmData.ocultar} onChange={onChange} />

                  <InputInput
                  type='text'
                  maxLength={255}
                  id='assunto'
                  label='Assunto'
                  dataForm={contatocrmData}
                  className='inputIncNome'
                  name='assunto'
                  value={contatocrmData.assunto}
                  onChange={onChange}
                  />

                  <InputCheckbox dataForm={contatocrmData} label='IsDocsRecebidos' name='isdocsrecebidos' checked={contatocrmData.isdocsrecebidos} onChange={onChange} />

                  <InputInput
                  type='text'
                  maxLength={2048}
                  id='quemnotificou'
                  label='QuemNotificou'
                  dataForm={contatocrmData}
                  className='inputIncNome'
                  name='quemnotificou'
                  value={contatocrmData.quemnotificou}
                  onChange={onChange}
                  />

                </div><div className='grid-container'>
                  <InputInput
                  type='text'
                  maxLength={2048}
                  id='datanotificou'
                  label='DataNotificou'
                  dataForm={contatocrmData}
                  className='inputIncNome'
                  name='datanotificou'
                  value={contatocrmData.datanotificou}
                  onChange={onChange}
                  />


                  <OperadorComboBox
                  name={'operador'}
                  dataForm={contatocrmData}
                  value={contatocrmData.operador}
                  setValue={addValorOperador}
                  label={'Operador'}
                  />

                  <ClientesComboBox
                  name={'cliente'}
                  dataForm={contatocrmData}
                  value={contatocrmData.cliente}
                  setValue={addValorCliente}
                  label={'Clientes'}
                  />

                  <InputInput
                  type='text'
                  maxLength={2048}
                  id='horanotificou'
                  label='HoraNotificou'
                  dataForm={contatocrmData}
                  className='inputIncNome'
                  name='horanotificou'
                  value={contatocrmData.horanotificou}
                  onChange={onChange}
                  />


                  <InputInput
                  type='text'
                  maxLength={2048}
                  id='objetonotificou'
                  label='ObjetoNotificou'
                  dataForm={contatocrmData}
                  className='inputIncNome'
                  name='objetonotificou'
                  value={contatocrmData.objetonotificou}
                  onChange={onChange}
                  />


                  <InputInput
                  type='text'
                  maxLength={255}
                  id='pessoacontato'
                  label='PessoaContato'
                  dataForm={contatocrmData}
                  className='inputIncNome'
                  name='pessoacontato'
                  value={contatocrmData.pessoacontato}
                  onChange={onChange}
                  />


                  <InputInput
                  type='text'
                  maxLength={2048}
                  id='data'
                  label='Data'
                  dataForm={contatocrmData}
                  className='inputIncNome'
                  name='data'
                  value={contatocrmData.data}
                  onChange={onChange}
                  />


                  <InputInput
                  type='text'
                  maxLength={2048}
                  id='tempo'
                  label='Tempo'
                  dataForm={contatocrmData}
                  className='inputIncNome'
                  name='tempo'
                  value={contatocrmData.tempo}
                  onChange={onChange}
                  />


                  <InputInput
                  type='text'
                  maxLength={2048}
                  id='horainicial'
                  label='HoraInicial'
                  dataForm={contatocrmData}
                  className='inputIncNome'
                  name='horainicial'
                  value={contatocrmData.horainicial}
                  onChange={onChange}
                  />

                </div><div className='grid-container'>
                  <InputInput
                  type='text'
                  maxLength={2048}
                  id='horafinal'
                  label='HoraFinal'
                  dataForm={contatocrmData}
                  className='inputIncNome'
                  name='horafinal'
                  value={contatocrmData.horafinal}
                  onChange={onChange}
                  />


                  <ProcessosComboBox
                  name={'processo'}
                  dataForm={contatocrmData}
                  value={contatocrmData.processo}
                  setValue={addValorProcesso}
                  label={'Processos'}
                  />
                  <InputCheckbox dataForm={contatocrmData} label='Importante' name='importante' checked={contatocrmData.importante} onChange={onChange} />
                  <InputCheckbox dataForm={contatocrmData} label='Urgente' name='urgente' checked={contatocrmData.urgente} onChange={onChange} />
                  <InputCheckbox dataForm={contatocrmData} label='GerarHoraTrabalhada' name='gerarhoratrabalhada' checked={contatocrmData.gerarhoratrabalhada} onChange={onChange} />
                  <InputCheckbox dataForm={contatocrmData} label='ExibirNoTopo' name='exibirnotopo' checked={contatocrmData.exibirnotopo} onChange={onChange} />

                  <TipoContatoCRMComboBox
                  name={'tipocontatocrm'}
                  dataForm={contatocrmData}
                  value={contatocrmData.tipocontatocrm}
                  setValue={addValorTipoContatoCRM}
                  label={'Tipo Contato C R M'}
                  />

                  <InputInput
                  type='text'
                  maxLength={2147483647}
                  id='contato'
                  label='Contato'
                  dataForm={contatocrmData}
                  className='inputIncNome'
                  name='contato'
                  value={contatocrmData.contato}
                  onChange={onChange}
                  />


                  <InputInput
                  type='text'
                  maxLength={2048}
                  id='emocao'
                  label='Emocao'
                  dataForm={contatocrmData}
                  className='inputIncNome'
                  name='emocao'
                  value={contatocrmData.emocao}
                  onChange={onChange}
                  />

                </div><div className='grid-container'><InputCheckbox dataForm={contatocrmData} label='Continuar' name='continuar' checked={contatocrmData.continuar} onChange={onChange} />
              </div>
            </form>


            {isMobile && (
              <ButtonSalvarCrud isMobile={true} validationForm={validationForm} entity='ContatoCRM' data={contatocrmData} isSubmitting={isSubmitting} onClose={onClose} formId={`ContatoCRMForm-${contatocrmData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
              )}
              <DeleteButton page={'/pages/contatocrm'} id={contatocrmData.id} closeModel={onClose} dadoApi={dadoApi} />
            </div>
            <div className='form-spacer'></div>
            </>
          );
        };