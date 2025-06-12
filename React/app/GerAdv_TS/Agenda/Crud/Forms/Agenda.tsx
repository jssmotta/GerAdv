// Tracking: Forms.tsx.txt
'use client';
import { IAgenda } from '@/app/GerAdv_TS/Agenda/Interfaces/interface.Agenda';
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
import { AgendaApi } from '../../Apis/ApiAgenda';
import { useValidationsAgenda } from '../../Hooks/hookAgenda';
import CidadeComboBox from '@/app/GerAdv_TS/Cidade/ComboBox/Cidade';
import AdvogadosComboBox from '@/app/GerAdv_TS/Advogados/ComboBox/Advogados';
import FuncionariosComboBox from '@/app/GerAdv_TS/Funcionarios/ComboBox/Funcionarios';
import TipoCompromissoComboBox from '@/app/GerAdv_TS/TipoCompromisso/ComboBox/TipoCompromisso';
import ClientesComboBox from '@/app/GerAdv_TS/Clientes/ComboBox/Clientes';
import AreaComboBox from '@/app/GerAdv_TS/Area/ComboBox/Area';
import JusticaComboBox from '@/app/GerAdv_TS/Justica/ComboBox/Justica';
import ProcessosComboBox from '@/app/GerAdv_TS/Processos/ComboBox/Processos';
import OperadorComboBox from '@/app/GerAdv_TS/Operador/ComboBox/Operador';
import PrepostosComboBox from '@/app/GerAdv_TS/Prepostos/ComboBox/Prepostos';
import { CidadeApi } from '@/app/GerAdv_TS/Cidade/Apis/ApiCidade';
import { AdvogadosApi } from '@/app/GerAdv_TS/Advogados/Apis/ApiAdvogados';
import { FuncionariosApi } from '@/app/GerAdv_TS/Funcionarios/Apis/ApiFuncionarios';
import { TipoCompromissoApi } from '@/app/GerAdv_TS/TipoCompromisso/Apis/ApiTipoCompromisso';
import { ClientesApi } from '@/app/GerAdv_TS/Clientes/Apis/ApiClientes';
import { AreaApi } from '@/app/GerAdv_TS/Area/Apis/ApiArea';
import { JusticaApi } from '@/app/GerAdv_TS/Justica/Apis/ApiJustica';
import { ProcessosApi } from '@/app/GerAdv_TS/Processos/Apis/ApiProcessos';
import { OperadorApi } from '@/app/GerAdv_TS/Operador/Apis/ApiOperador';
import { PrepostosApi } from '@/app/GerAdv_TS/Prepostos/Apis/ApiPrepostos';
import InputName from '@/app/components/Inputs/InputName';
import InputInput from '@/app/components/Inputs/InputInput'
import InputCheckbox from '@/app/components/Inputs/InputCheckbox';
interface AgendaFormProps {
  agendaData: IAgenda;
  onChange: (e: any) => void;
  onSubmit: (e: React.FormEvent) => void;
  onClose: () => void;
  onError?: () => void;
  onReload?: () => void;
  onSuccess?: (registro?: any) => void;
}

export const AgendaForm: React.FC<AgendaFormProps> = ({
  agendaData, 
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
const dadoApi = new AgendaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [isSubmitting, setIsSubmitting] = useState(false);
const initialized = useRef(false);
const validationForm = useValidationsAgenda();
const [nomeCidade, setNomeCidade] = useState('');
const cidadeApi = new CidadeApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeAdvogados, setNomeAdvogados] = useState('');
const advogadosApi = new AdvogadosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeFuncionarios, setNomeFuncionarios] = useState('');
const funcionariosApi = new FuncionariosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeTipoCompromisso, setNomeTipoCompromisso] = useState('');
const tipocompromissoApi = new TipoCompromissoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeClientes, setNomeClientes] = useState('');
const clientesApi = new ClientesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeArea, setNomeArea] = useState('');
const areaApi = new AreaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeJustica, setNomeJustica] = useState('');
const justicaApi = new JusticaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeProcessos, setNomeProcessos] = useState('');
const processosApi = new ProcessosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeOperador, setNomeOperador] = useState('');
const operadorApi = new OperadorApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomePrepostos, setNomePrepostos] = useState('');
const prepostosApi = new PrepostosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

if (getParamFromUrl('cidade') > 0) {
  if (agendaData.id === 0 && agendaData.cidade == 0) {
    cidadeApi
    .getById(getParamFromUrl('cidade'))
    .then((response) => {
      setNomeCidade(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

    agendaData.cidade = getParamFromUrl('cidade');
  }
}

if (getParamFromUrl('advogados') > 0) {
  if (agendaData.id === 0 && agendaData.advogado == 0) {
    advogadosApi
    .getById(getParamFromUrl('advogados'))
    .then((response) => {
      setNomeAdvogados(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

    agendaData.advogado = getParamFromUrl('advogados');
  }
}

if (getParamFromUrl('funcionarios') > 0) {
  if (agendaData.id === 0 && agendaData.funcionario == 0) {
    funcionariosApi
    .getById(getParamFromUrl('funcionarios'))
    .then((response) => {
      setNomeFuncionarios(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

    agendaData.funcionario = getParamFromUrl('funcionarios');
  }
}

if (getParamFromUrl('tipocompromisso') > 0) {
  if (agendaData.id === 0 && agendaData.tipocompromisso == 0) {
    tipocompromissoApi
    .getById(getParamFromUrl('tipocompromisso'))
    .then((response) => {
      setNomeTipoCompromisso(response.data.descricao);
    })
    .catch((error) => {
      console.error(error);
    });

    agendaData.tipocompromisso = getParamFromUrl('tipocompromisso');
  }
}

if (getParamFromUrl('clientes') > 0) {
  if (agendaData.id === 0 && agendaData.cliente == 0) {
    clientesApi
    .getById(getParamFromUrl('clientes'))
    .then((response) => {
      setNomeClientes(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

    agendaData.cliente = getParamFromUrl('clientes');
  }
}

if (getParamFromUrl('area') > 0) {
  if (agendaData.id === 0 && agendaData.area == 0) {
    areaApi
    .getById(getParamFromUrl('area'))
    .then((response) => {
      setNomeArea(response.data.descricao);
    })
    .catch((error) => {
      console.error(error);
    });

    agendaData.area = getParamFromUrl('area');
  }
}

if (getParamFromUrl('justica') > 0) {
  if (agendaData.id === 0 && agendaData.justica == 0) {
    justicaApi
    .getById(getParamFromUrl('justica'))
    .then((response) => {
      setNomeJustica(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

    agendaData.justica = getParamFromUrl('justica');
  }
}

if (getParamFromUrl('processos') > 0) {
  if (agendaData.id === 0 && agendaData.processo == 0) {
    processosApi
    .getById(getParamFromUrl('processos'))
    .then((response) => {
      setNomeProcessos(response.data.nropasta);
    })
    .catch((error) => {
      console.error(error);
    });

    agendaData.processo = getParamFromUrl('processos');
  }
}

if (getParamFromUrl('operador') > 0) {
  if (agendaData.id === 0 && agendaData.usuario == 0) {
    operadorApi
    .getById(getParamFromUrl('operador'))
    .then((response) => {
      setNomeOperador(response.data.rnome);
    })
    .catch((error) => {
      console.error(error);
    });

    agendaData.usuario = getParamFromUrl('operador');
  }
}

if (getParamFromUrl('prepostos') > 0) {
  if (agendaData.id === 0 && agendaData.preposto == 0) {
    prepostosApi
    .getById(getParamFromUrl('prepostos'))
    .then((response) => {
      setNomePrepostos(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

    agendaData.preposto = getParamFromUrl('prepostos');
  }
}
const addValorCidade = (e: any) => {
  if (e?.id>0)
    agendaData.cidade = e.id;
  };
  const addValorAdvogado = (e: any) => {
    if (e?.id>0)
      agendaData.advogado = e.id;
    };
    const addValorFuncionario = (e: any) => {
      if (e?.id>0)
        agendaData.funcionario = e.id;
      };
      const addValorTipoCompromisso = (e: any) => {
        if (e?.id>0)
          agendaData.tipocompromisso = e.id;
        };
        const addValorCliente = (e: any) => {
          if (e?.id>0)
            agendaData.cliente = e.id;
          };
          const addValorArea = (e: any) => {
            if (e?.id>0)
              agendaData.area = e.id;
            };
            const addValorJustica = (e: any) => {
              if (e?.id>0)
                agendaData.justica = e.id;
              };
              const addValorProcesso = (e: any) => {
                if (e?.id>0)
                  agendaData.processo = e.id;
                };
                const addValorUsuario = (e: any) => {
                  if (e?.id>0)
                    agendaData.usuario = e.id;
                  };
                  const addValorPreposto = (e: any) => {
                    if (e?.id>0)
                      agendaData.preposto = e.id;
                    };
                    const onConfirm = (e: React.FormEvent) => {
                      e.preventDefault();
                      if (e.stopPropagation) e.stopPropagation();

                        if (!isSubmitting) {
                          setIsSubmitting(true);

                          try {
                            onSubmit(e);
                          } catch (error) {
                          console.error('Erro ao submeter formulário de Agenda:', error);
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
                            target: document.getElementById(`AgendaForm-${agendaData.id}`)
                          } as unknown as React.FormEvent;

                          onSubmit(syntheticEvent);
                        } catch (error) {
                        console.error('Erro ao salvar Agenda diretamente:', error);
                        setIsSubmitting(false);
                        if (onError) onError();
                        }
                      }
                    };
                    useEffect(() => {
                      const el = document.querySelector('.nameFormMobile');
                      if (el) {
                        el.textContent = agendaData?.id == 0 ? 'Editar Agenda' : 'Adicionar Agenda';
                      }
                    }, [agendaData.id]);
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

                      <div className={isMobile ? 'form-container form-container-Agenda' : 'form-container form-container-Agenda'}>

                        <form className='formInputCadInc' id={`AgendaForm-${agendaData.id}`} onSubmit={onConfirm}>
                          {!isMobile && (
                            <ButtonSalvarCrud isMobile={false} validationForm={validationForm} entity='Agenda' data={agendaData} isSubmitting={isSubmitting} onClose={onClose} formId={`AgendaForm-${agendaData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
                            )}
                            <div className='grid-container'>


                              <InputInput
                              type='text'
                              maxLength={2048}
                              id='idcob'
                              label='IDCOB'
                              dataForm={agendaData}
                              className='inputIncNome'
                              name='idcob'
                              value={agendaData.idcob}
                              onChange={onChange}
                              />

                              <InputCheckbox dataForm={agendaData} label='ClienteAvisado' name='clienteavisado' checked={agendaData.clienteavisado} onChange={onChange} />
                              <InputCheckbox dataForm={agendaData} label='RevisarP2' name='revisarp2' checked={agendaData.revisarp2} onChange={onChange} />

                              <InputInput
                              type='text'
                              maxLength={2048}
                              id='idne'
                              label='IDNE'
                              dataForm={agendaData}
                              className='inputIncNome'
                              name='idne'
                              value={agendaData.idne}
                              onChange={onChange}
                              />


                              <CidadeComboBox
                              name={'cidade'}
                              dataForm={agendaData}
                              value={agendaData.cidade}
                              setValue={addValorCidade}
                              label={'Cidade'}
                              />

                              <InputInput
                              type='text'
                              maxLength={2048}
                              id='oculto'
                              label='Oculto'
                              dataForm={agendaData}
                              className='inputIncNome'
                              name='oculto'
                              value={agendaData.oculto}
                              onChange={onChange}
                              />


                              <InputInput
                              type='text'
                              maxLength={2048}
                              id='cartaprecatoria'
                              label='CartaPrecatoria'
                              dataForm={agendaData}
                              className='inputIncNome'
                              name='cartaprecatoria'
                              value={agendaData.cartaprecatoria}
                              onChange={onChange}
                              />

                              <InputCheckbox dataForm={agendaData} label='Revisar' name='revisar' checked={agendaData.revisar} onChange={onChange} />

                              <InputInput
                              type='text'
                              maxLength={2048}
                              id='hrfinal'
                              label='HrFinal'
                              dataForm={agendaData}
                              className='inputIncNome'
                              name='hrfinal'
                              value={agendaData.hrfinal}
                              onChange={onChange}
                              />

                            </div><div className='grid-container'>
                              <AdvogadosComboBox
                              name={'advogado'}
                              dataForm={agendaData}
                              value={agendaData.advogado}
                              setValue={addValorAdvogado}
                              label={'Advogados'}
                              />

                              <InputInput
                              type='text'
                              maxLength={2048}
                              id='eventogerador'
                              label='EventoGerador'
                              dataForm={agendaData}
                              className='inputIncNome'
                              name='eventogerador'
                              value={agendaData.eventogerador}
                              onChange={onChange}
                              />


                              <InputInput
                              type='text'
                              maxLength={2048}
                              id='eventodata'
                              label='EventoData'
                              dataForm={agendaData}
                              className='inputIncNome'
                              name='eventodata'
                              value={agendaData.eventodata}
                              onChange={onChange}
                              />


                              <FuncionariosComboBox
                              name={'funcionario'}
                              dataForm={agendaData}
                              value={agendaData.funcionario}
                              setValue={addValorFuncionario}
                              label={'Colaborador'}
                              />

                              <InputInput
                              type='text'
                              maxLength={2048}
                              id='data'
                              label='Data'
                              dataForm={agendaData}
                              className='inputIncNome'
                              name='data'
                              value={agendaData.data}
                              onChange={onChange}
                              />


                              <InputInput
                              type='text'
                              maxLength={2048}
                              id='eventoprazo'
                              label='EventoPrazo'
                              dataForm={agendaData}
                              className='inputIncNome'
                              name='eventoprazo'
                              value={agendaData.eventoprazo}
                              onChange={onChange}
                              />


                              <InputInput
                              type='text'
                              maxLength={2048}
                              id='hora'
                              label='Hora'
                              dataForm={agendaData}
                              className='inputIncNome'
                              name='hora'
                              value={agendaData.hora}
                              onChange={onChange}
                              />


                              <InputInput
                              type='text'
                              maxLength={2147483647}
                              id='compromisso'
                              label='Compromisso'
                              dataForm={agendaData}
                              className='inputIncNome'
                              name='compromisso'
                              value={agendaData.compromisso}
                              onChange={onChange}
                              />


                              <TipoCompromissoComboBox
                              name={'tipocompromisso'}
                              dataForm={agendaData}
                              value={agendaData.tipocompromisso}
                              setValue={addValorTipoCompromisso}
                              label={'Tipo Compromisso'}
                              />

                              <ClientesComboBox
                              name={'cliente'}
                              dataForm={agendaData}
                              value={agendaData.cliente}
                              setValue={addValorCliente}
                              label={'Clientes'}
                              />
                            </div><div className='grid-container'><InputCheckbox dataForm={agendaData} label='Liberado' name='liberado' checked={agendaData.liberado} onChange={onChange} />
                            <InputCheckbox dataForm={agendaData} label='Importante' name='importante' checked={agendaData.importante} onChange={onChange} />
                            <InputCheckbox dataForm={agendaData} label='Concluido' name='concluido' checked={agendaData.concluido} onChange={onChange} />

                            <AreaComboBox
                            name={'area'}
                            dataForm={agendaData}
                            value={agendaData.area}
                            setValue={addValorArea}
                            label={'Area'}
                            />

                            <JusticaComboBox
                            name={'justica'}
                            dataForm={agendaData}
                            value={agendaData.justica}
                            setValue={addValorJustica}
                            label={'Justica'}
                            />

                            <ProcessosComboBox
                            name={'processo'}
                            dataForm={agendaData}
                            value={agendaData.processo}
                            setValue={addValorProcesso}
                            label={'Processos'}
                            />

                            <InputInput
                            type='text'
                            maxLength={2048}
                            id='idhistorico'
                            label='IDHistorico'
                            dataForm={agendaData}
                            className='inputIncNome'
                            name='idhistorico'
                            value={agendaData.idhistorico}
                            onChange={onChange}
                            />


                            <InputInput
                            type='text'
                            maxLength={2048}
                            id='idinsprocesso'
                            label='IDInsProcesso'
                            dataForm={agendaData}
                            className='inputIncNome'
                            name='idinsprocesso'
                            value={agendaData.idinsprocesso}
                            onChange={onChange}
                            />


                            <OperadorComboBox
                            name={'usuario'}
                            dataForm={agendaData}
                            value={agendaData.usuario}
                            setValue={addValorUsuario}
                            label={'Operador'}
                            />

                            <PrepostosComboBox
                            name={'preposto'}
                            dataForm={agendaData}
                            value={agendaData.preposto}
                            setValue={addValorPreposto}
                            label={'Prepostos'}
                            />
                          </div><div className='grid-container'>
                            <InputInput
                            type='text'
                            maxLength={2048}
                            id='quemid'
                            label='QuemID'
                            dataForm={agendaData}
                            className='inputIncNome'
                            name='quemid'
                            value={agendaData.quemid}
                            onChange={onChange}
                            />


                            <InputInput
                            type='text'
                            maxLength={2048}
                            id='quemcodigo'
                            label='QuemCodigo'
                            dataForm={agendaData}
                            className='inputIncNome'
                            name='quemcodigo'
                            value={agendaData.quemcodigo}
                            onChange={onChange}
                            />


                            <InputInput
                            type='text'
                            maxLength={2147483647}
                            id='status'
                            label='Status'
                            dataForm={agendaData}
                            className='inputIncNome'
                            name='status'
                            value={agendaData.status}
                            onChange={onChange}
                            />


                            <InputInput
                            type='text'
                            maxLength={2048}
                            id='valor'
                            label='Valor'
                            dataForm={agendaData}
                            className='inputIncNome'
                            name='valor'
                            value={agendaData.valor}
                            onChange={onChange}
                            />


                            <InputInput
                            type='text'
                            maxLength={2048}
                            id='decisao'
                            label='Decisao'
                            dataForm={agendaData}
                            className='inputIncNome'
                            name='decisao'
                            value={agendaData.decisao}
                            onChange={onChange}
                            />


                            <InputInput
                            type='text'
                            maxLength={2048}
                            id='sempre'
                            label='Sempre'
                            dataForm={agendaData}
                            className='inputIncNome'
                            name='sempre'
                            value={agendaData.sempre}
                            onChange={onChange}
                            />


                            <InputInput
                            type='text'
                            maxLength={2048}
                            id='prazodias'
                            label='PrazoDias'
                            dataForm={agendaData}
                            className='inputIncNome'
                            name='prazodias'
                            value={agendaData.prazodias}
                            onChange={onChange}
                            />


                            <InputInput
                            type='text'
                            maxLength={2048}
                            id='protocolointegrado'
                            label='ProtocoloIntegrado'
                            dataForm={agendaData}
                            className='inputIncNome'
                            name='protocolointegrado'
                            value={agendaData.protocolointegrado}
                            onChange={onChange}
                            />


                            <InputInput
                            type='text'
                            maxLength={2048}
                            id='datainicioprazo'
                            label='DataInicioPrazo'
                            dataForm={agendaData}
                            className='inputIncNome'
                            name='datainicioprazo'
                            value={agendaData.datainicioprazo}
                            onChange={onChange}
                            />

                            <InputCheckbox dataForm={agendaData} label='UsuarioCiente' name='usuariociente' checked={agendaData.usuariociente} onChange={onChange} />
                          </div>
                        </form>


                        {isMobile && (
                          <ButtonSalvarCrud isMobile={true} validationForm={validationForm} entity='Agenda' data={agendaData} isSubmitting={isSubmitting} onClose={onClose} formId={`AgendaForm-${agendaData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
                          )}
                          <DeleteButton page={'/pages/agenda'} id={agendaData.id} closeModel={onClose} dadoApi={dadoApi} />
                        </div>
                        <div className='form-spacer'></div>
                        </>
                      );
                    };