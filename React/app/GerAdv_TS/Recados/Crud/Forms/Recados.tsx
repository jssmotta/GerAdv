// Tracking: Forms.tsx.txt
'use client';
import { IRecados } from '@/app/GerAdv_TS/Recados/Interfaces/interface.Recados';
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
import { RecadosApi } from '../../Apis/ApiRecados';
import { useValidationsRecados } from '../../Hooks/hookRecados';
import ProcessosComboBox from '@/app/GerAdv_TS/Processos/ComboBox/Processos';
import ClientesComboBox from '@/app/GerAdv_TS/Clientes/ComboBox/Clientes';
import HistoricoComboBox from '@/app/GerAdv_TS/Historico/ComboBox/Historico';
import ContatoCRMComboBox from '@/app/GerAdv_TS/ContatoCRM/ComboBox/ContatoCRM';
import LigacoesComboBox from '@/app/GerAdv_TS/Ligacoes/ComboBox/Ligacoes';
import AgendaComboBox from '@/app/GerAdv_TS/Agenda/ComboBox/Agenda';
import { ProcessosApi } from '@/app/GerAdv_TS/Processos/Apis/ApiProcessos';
import { ClientesApi } from '@/app/GerAdv_TS/Clientes/Apis/ApiClientes';
import { HistoricoApi } from '@/app/GerAdv_TS/Historico/Apis/ApiHistorico';
import { ContatoCRMApi } from '@/app/GerAdv_TS/ContatoCRM/Apis/ApiContatoCRM';
import { LigacoesApi } from '@/app/GerAdv_TS/Ligacoes/Apis/ApiLigacoes';
import { AgendaApi } from '@/app/GerAdv_TS/Agenda/Apis/ApiAgenda';
import InputName from '@/app/components/Inputs/InputName';
import InputInput from '@/app/components/Inputs/InputInput'
import InputCheckbox from '@/app/components/Inputs/InputCheckbox';
interface RecadosFormProps {
  recadosData: IRecados;
  onChange: (e: any) => void;
  onSubmit: (e: React.FormEvent) => void;
  onClose: () => void;
  onError?: () => void;
  onReload?: () => void;
  onSuccess?: (registro?: any) => void;
}

export const RecadosForm: React.FC<RecadosFormProps> = ({
  recadosData, 
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
const dadoApi = new RecadosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [isSubmitting, setIsSubmitting] = useState(false);
const initialized = useRef(false);
const validationForm = useValidationsRecados();
const [nomeProcessos, setNomeProcessos] = useState('');
const processosApi = new ProcessosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeClientes, setNomeClientes] = useState('');
const clientesApi = new ClientesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeHistorico, setNomeHistorico] = useState('');
const historicoApi = new HistoricoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeContatoCRM, setNomeContatoCRM] = useState('');
const contatocrmApi = new ContatoCRMApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeLigacoes, setNomeLigacoes] = useState('');
const ligacoesApi = new LigacoesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeAgenda, setNomeAgenda] = useState('');
const agendaApi = new AgendaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

if (getParamFromUrl('processos') > 0) {
  if (recadosData.id === 0 && recadosData.processo == 0) {
    processosApi
    .getById(getParamFromUrl('processos'))
    .then((response) => {
      setNomeProcessos(response.data.nropasta);
    })
    .catch((error) => {
      console.error(error);
    });

    recadosData.processo = getParamFromUrl('processos');
  }
}

if (getParamFromUrl('clientes') > 0) {
  if (recadosData.id === 0 && recadosData.cliente == 0) {
    clientesApi
    .getById(getParamFromUrl('clientes'))
    .then((response) => {
      setNomeClientes(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

    recadosData.cliente = getParamFromUrl('clientes');
  }
}

if (getParamFromUrl('historico') > 0) {
  if (recadosData.id === 0 && recadosData.historico == 0) {
    historicoApi
    .getById(getParamFromUrl('historico'))
    .then((response) => {
      setNomeHistorico(response.data.campo);
    })
    .catch((error) => {
      console.error(error);
    });

    recadosData.historico = getParamFromUrl('historico');
  }
}

if (getParamFromUrl('contatocrm') > 0) {
  if (recadosData.id === 0 && recadosData.contatocrm == 0) {
    contatocrmApi
    .getById(getParamFromUrl('contatocrm'))
    .then((response) => {
      setNomeContatoCRM(response.data.campo);
    })
    .catch((error) => {
      console.error(error);
    });

    recadosData.contatocrm = getParamFromUrl('contatocrm');
  }
}

if (getParamFromUrl('ligacoes') > 0) {
  if (recadosData.id === 0 && recadosData.ligacoes == 0) {
    ligacoesApi
    .getById(getParamFromUrl('ligacoes'))
    .then((response) => {
      setNomeLigacoes(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

    recadosData.ligacoes = getParamFromUrl('ligacoes');
  }
}

if (getParamFromUrl('agenda') > 0) {
  if (recadosData.id === 0 && recadosData.agenda == 0) {
    agendaApi
    .getById(getParamFromUrl('agenda'))
    .then((response) => {
      setNomeAgenda(response.data.campo);
    })
    .catch((error) => {
      console.error(error);
    });

    recadosData.agenda = getParamFromUrl('agenda');
  }
}
const addValorProcesso = (e: any) => {
  if (e?.id>0)
    recadosData.processo = e.id;
  };
  const addValorCliente = (e: any) => {
    if (e?.id>0)
      recadosData.cliente = e.id;
    };
    const addValorHistorico = (e: any) => {
      if (e?.id>0)
        recadosData.historico = e.id;
      };
      const addValorContatoCRM = (e: any) => {
        if (e?.id>0)
          recadosData.contatocrm = e.id;
        };
        const addValorLigacoes = (e: any) => {
          if (e?.id>0)
            recadosData.ligacoes = e.id;
          };
          const addValorAgenda = (e: any) => {
            if (e?.id>0)
              recadosData.agenda = e.id;
            };
            const onConfirm = (e: React.FormEvent) => {
              e.preventDefault();
              if (e.stopPropagation) e.stopPropagation();

                if (!isSubmitting) {
                  setIsSubmitting(true);

                  try {
                    onSubmit(e);
                  } catch (error) {
                  console.error('Erro ao submeter formulário de Recados:', error);
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
                    target: document.getElementById(`RecadosForm-${recadosData.id}`)
                  } as unknown as React.FormEvent;

                  onSubmit(syntheticEvent);
                } catch (error) {
                console.error('Erro ao salvar Recados diretamente:', error);
                setIsSubmitting(false);
                if (onError) onError();
                }
              }
            };
            useEffect(() => {
              const el = document.querySelector('.nameFormMobile');
              if (el) {
                el.textContent = recadosData?.id == 0 ? 'Editar Recados' : 'Adicionar Recados';
              }
            }, [recadosData.id]);
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

              <div className={isMobile ? 'form-container form-container-Recados' : 'form-container form-container-Recados'}>

                <form className='formInputCadInc' id={`RecadosForm-${recadosData.id}`} onSubmit={onConfirm}>
                  {!isMobile && (
                    <ButtonSalvarCrud isMobile={false} validationForm={validationForm} entity='Recados' data={recadosData} isSubmitting={isSubmitting} onClose={onClose} formId={`RecadosForm-${recadosData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
                    )}
                    <div className='grid-container'>


                      <InputInput
                      type='text'
                      maxLength={255}
                      id='clientenome'
                      label='ClienteNome'
                      dataForm={recadosData}
                      className='inputIncNome'
                      name='clientenome'
                      value={recadosData.clientenome}
                      onChange={onChange}
                      />


                      <InputInput
                      type='text'
                      maxLength={50}
                      id='de'
                      label='De'
                      dataForm={recadosData}
                      className='inputIncNome'
                      name='de'
                      value={recadosData.de}
                      onChange={onChange}
                      />


                      <InputInput
                      type='text'
                      maxLength={50}
                      id='para'
                      label='Para'
                      dataForm={recadosData}
                      className='inputIncNome'
                      name='para'
                      value={recadosData.para}
                      onChange={onChange}
                      />


                      <InputInput
                      type='text'
                      maxLength={255}
                      id='assunto'
                      label='Assunto'
                      dataForm={recadosData}
                      className='inputIncNome'
                      name='assunto'
                      value={recadosData.assunto}
                      onChange={onChange}
                      />

                      <InputCheckbox dataForm={recadosData} label='Concluido' name='concluido' checked={recadosData.concluido} onChange={onChange} />

                      <ProcessosComboBox
                      name={'processo'}
                      dataForm={recadosData}
                      value={recadosData.processo}
                      setValue={addValorProcesso}
                      label={'Processos'}
                      />

                      <ClientesComboBox
                      name={'cliente'}
                      dataForm={recadosData}
                      value={recadosData.cliente}
                      setValue={addValorCliente}
                      label={'Clientes'}
                      />

                      <InputInput
                      type='text'
                      maxLength={2147483647}
                      id='recado'
                      label='Recado'
                      dataForm={recadosData}
                      className='inputIncNome'
                      name='recado'
                      value={recadosData.recado}
                      onChange={onChange}
                      />

                    </div><div className='grid-container'><InputCheckbox dataForm={recadosData} label='Urgente' name='urgente' checked={recadosData.urgente} onChange={onChange} />
                    <InputCheckbox dataForm={recadosData} label='Importante' name='importante' checked={recadosData.importante} onChange={onChange} />

                    <InputInput
                    type='text'
                    maxLength={2048}
                    id='hora'
                    label='Hora'
                    dataForm={recadosData}
                    className='inputIncNome'
                    name='hora'
                    value={recadosData.hora}
                    onChange={onChange}
                    />


                    <InputInput
                    type='text'
                    maxLength={2048}
                    id='data'
                    label='Data'
                    dataForm={recadosData}
                    className='inputIncNome'
                    name='data'
                    value={recadosData.data}
                    onChange={onChange}
                    />

                    <InputCheckbox dataForm={recadosData} label='Voltara' name='voltara' checked={recadosData.voltara} onChange={onChange} />
                    <InputCheckbox dataForm={recadosData} label='Pessoal' name='pessoal' checked={recadosData.pessoal} onChange={onChange} />
                    <InputCheckbox dataForm={recadosData} label='Retornar' name='retornar' checked={recadosData.retornar} onChange={onChange} />

                    <InputInput
                    type='text'
                    maxLength={2048}
                    id='retornodata'
                    label='RetornoData'
                    dataForm={recadosData}
                    className='inputIncNome'
                    name='retornodata'
                    value={recadosData.retornodata}
                    onChange={onChange}
                    />


                    <InputInput
                    type='text'
                    maxLength={2048}
                    id='emotion'
                    label='Emotion'
                    dataForm={recadosData}
                    className='inputIncNome'
                    name='emotion'
                    value={recadosData.emotion}
                    onChange={onChange}
                    />

                  </div><div className='grid-container'>
                    <InputInput
                    type='text'
                    maxLength={2048}
                    id='internetid'
                    label='InternetID'
                    dataForm={recadosData}
                    className='inputIncNome'
                    name='internetid'
                    value={recadosData.internetid}
                    onChange={onChange}
                    />

                    <InputCheckbox dataForm={recadosData} label='Uploaded' name='uploaded' checked={recadosData.uploaded} onChange={onChange} />

                    <InputInput
                    type='text'
                    maxLength={2048}
                    id='natureza'
                    label='Natureza'
                    dataForm={recadosData}
                    className='inputIncNome'
                    name='natureza'
                    value={recadosData.natureza}
                    onChange={onChange}
                    />

                    <InputCheckbox dataForm={recadosData} label='BIU' name='biu' checked={recadosData.biu} onChange={onChange} />
                    <InputCheckbox dataForm={recadosData} label='AguardarRetorno' name='aguardarretorno' checked={recadosData.aguardarretorno} onChange={onChange} />

                    <InputInput
                    type='text'
                    maxLength={255}
                    id='aguardarretornopara'
                    label='AguardarRetornoPara'
                    dataForm={recadosData}
                    className='inputIncNome'
                    name='aguardarretornopara'
                    value={recadosData.aguardarretornopara}
                    onChange={onChange}
                    />

                    <InputCheckbox dataForm={recadosData} label='AguardarRetornoOK' name='aguardarretornook' checked={recadosData.aguardarretornook} onChange={onChange} />

                    <InputInput
                    type='text'
                    maxLength={2048}
                    id='paraid'
                    label='ParaID'
                    dataForm={recadosData}
                    className='inputIncNome'
                    name='paraid'
                    value={recadosData.paraid}
                    onChange={onChange}
                    />

                    <InputCheckbox dataForm={recadosData} label='NaoPublicavel' name='naopublicavel' checked={recadosData.naopublicavel} onChange={onChange} />
                  </div><div className='grid-container'><InputCheckbox dataForm={recadosData} label='IsContatoCRM' name='iscontatocrm' checked={recadosData.iscontatocrm} onChange={onChange} />

                  <InputInput
                  type='text'
                  maxLength={2048}
                  id='masterid'
                  label='MasterID'
                  dataForm={recadosData}
                  className='inputIncNome'
                  name='masterid'
                  value={recadosData.masterid}
                  onChange={onChange}
                  />


                  <InputInput
                  type='text'
                  maxLength={2147483647}
                  id='listapara'
                  label='ListaPara'
                  dataForm={recadosData}
                  className='inputIncNome'
                  name='listapara'
                  value={recadosData.listapara}
                  onChange={onChange}
                  />

                  <InputCheckbox dataForm={recadosData} label='Typed' name='typed' checked={recadosData.typed} onChange={onChange} />

                  <InputInput
                  type='text'
                  maxLength={2048}
                  id='assuntorecado'
                  label='AssuntoRecado'
                  dataForm={recadosData}
                  className='inputIncNome'
                  name='assuntorecado'
                  value={recadosData.assuntorecado}
                  onChange={onChange}
                  />


                  <HistoricoComboBox
                  name={'historico'}
                  dataForm={recadosData}
                  value={recadosData.historico}
                  setValue={addValorHistorico}
                  label={'Historico'}
                  />

                  <ContatoCRMComboBox
                  name={'contatocrm'}
                  dataForm={recadosData}
                  value={recadosData.contatocrm}
                  setValue={addValorContatoCRM}
                  label={'Contato C R M'}
                  />

                  <LigacoesComboBox
                  name={'ligacoes'}
                  dataForm={recadosData}
                  value={recadosData.ligacoes}
                  setValue={addValorLigacoes}
                  label={'Ligacoes'}
                  />

                  <AgendaComboBox
                  name={'agenda'}
                  dataForm={recadosData}
                  value={recadosData.agenda}
                  setValue={addValorAgenda}
                  label={'Agenda'}
                  />
                </div>
              </form>


              {isMobile && (
                <ButtonSalvarCrud isMobile={true} validationForm={validationForm} entity='Recados' data={recadosData} isSubmitting={isSubmitting} onClose={onClose} formId={`RecadosForm-${recadosData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
                )}
                <DeleteButton page={'/pages/recados'} id={recadosData.id} closeModel={onClose} dadoApi={dadoApi} />
              </div>
              <div className='form-spacer'></div>
              </>
            );
          };