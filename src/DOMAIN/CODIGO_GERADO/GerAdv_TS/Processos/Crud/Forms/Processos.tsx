// Tracking: Forms.tsx.txt
'use client';
import { IProcessos } from '@/app/GerAdv_TS/Processos/Interfaces/interface.Processos';
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
import { ProcessosApi } from '../../Apis/ApiProcessos';
import { useValidationsProcessos } from '../../Hooks/hookProcessos';
import AdvogadosComboBox from '@/app/GerAdv_TS/Advogados/ComboBox/Advogados';
import JusticaComboBox from '@/app/GerAdv_TS/Justica/ComboBox/Justica';
import AdvogadosComboBox from '@/app/GerAdv_TS/Advogados/ComboBox/Advogados';
import PrepostosComboBox from '@/app/GerAdv_TS/Prepostos/ComboBox/Prepostos';
import ClientesComboBox from '@/app/GerAdv_TS/Clientes/ComboBox/Clientes';
import OponentesComboBox from '@/app/GerAdv_TS/Oponentes/ComboBox/Oponentes';
import AreaComboBox from '@/app/GerAdv_TS/Area/ComboBox/Area';
import CidadeComboBox from '@/app/GerAdv_TS/Cidade/ComboBox/Cidade';
import SituacaoComboBox from '@/app/GerAdv_TS/Situacao/ComboBox/Situacao';
import RitoComboBox from '@/app/GerAdv_TS/Rito/ComboBox/Rito';
import AtividadesComboBox from '@/app/GerAdv_TS/Atividades/ComboBox/Atividades';
import { AdvogadosApi } from '@/app/GerAdv_TS/Advogados/Apis/ApiAdvogados';
import { JusticaApi } from '@/app/GerAdv_TS/Justica/Apis/ApiJustica';
import { PrepostosApi } from '@/app/GerAdv_TS/Prepostos/Apis/ApiPrepostos';
import { ClientesApi } from '@/app/GerAdv_TS/Clientes/Apis/ApiClientes';
import { OponentesApi } from '@/app/GerAdv_TS/Oponentes/Apis/ApiOponentes';
import { AreaApi } from '@/app/GerAdv_TS/Area/Apis/ApiArea';
import { CidadeApi } from '@/app/GerAdv_TS/Cidade/Apis/ApiCidade';
import { SituacaoApi } from '@/app/GerAdv_TS/Situacao/Apis/ApiSituacao';
import { RitoApi } from '@/app/GerAdv_TS/Rito/Apis/ApiRito';
import { AtividadesApi } from '@/app/GerAdv_TS/Atividades/Apis/ApiAtividades';
import InputName from '@/app/components/Inputs/InputName';
import InputInput from '@/app/components/Inputs/InputInput'
import InputCheckbox from '@/app/components/Inputs/InputCheckbox';
interface ProcessosFormProps {
  processosData: IProcessos;
  onChange: (e: any) => void;
  onSubmit: (e: React.FormEvent) => void;
  onClose: () => void;
  onError?: () => void;
  onReload?: () => void;
  onSuccess?: (registro?: any) => void;
}

export const ProcessosForm: React.FC<ProcessosFormProps> = ({
  processosData, 
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
const dadoApi = new ProcessosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [isSubmitting, setIsSubmitting] = useState(false);
const initialized = useRef(false);
const validationForm = useValidationsProcessos();
const [nomeAdvogados, setNomeAdvogados] = useState('');
const advogadosApi = new AdvogadosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeJustica, setNomeJustica] = useState('');
const justicaApi = new JusticaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomePrepostos, setNomePrepostos] = useState('');
const prepostosApi = new PrepostosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeClientes, setNomeClientes] = useState('');
const clientesApi = new ClientesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeOponentes, setNomeOponentes] = useState('');
const oponentesApi = new OponentesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeArea, setNomeArea] = useState('');
const areaApi = new AreaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeCidade, setNomeCidade] = useState('');
const cidadeApi = new CidadeApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeSituacao, setNomeSituacao] = useState('');
const situacaoApi = new SituacaoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeRito, setNomeRito] = useState('');
const ritoApi = new RitoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeAtividades, setNomeAtividades] = useState('');
const atividadesApi = new AtividadesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

if (getParamFromUrl('advogados') > 0) {
  if (processosData.id === 0 && processosData.advopo == 0) {
    advogadosApi
    .getById(getParamFromUrl('advogados'))
    .then((response) => {
      setNomeAdvogados(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

    processosData.advopo = getParamFromUrl('advogados');
  }
}

if (getParamFromUrl('justica') > 0) {
  if (processosData.id === 0 && processosData.justica == 0) {
    justicaApi
    .getById(getParamFromUrl('justica'))
    .then((response) => {
      setNomeJustica(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

    processosData.justica = getParamFromUrl('justica');
  }
}

if (getParamFromUrl('prepostos') > 0) {
  if (processosData.id === 0 && processosData.preposto == 0) {
    prepostosApi
    .getById(getParamFromUrl('prepostos'))
    .then((response) => {
      setNomePrepostos(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

    processosData.preposto = getParamFromUrl('prepostos');
  }
}

if (getParamFromUrl('clientes') > 0) {
  if (processosData.id === 0 && processosData.cliente == 0) {
    clientesApi
    .getById(getParamFromUrl('clientes'))
    .then((response) => {
      setNomeClientes(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

    processosData.cliente = getParamFromUrl('clientes');
  }
}

if (getParamFromUrl('oponentes') > 0) {
  if (processosData.id === 0 && processosData.oponente == 0) {
    oponentesApi
    .getById(getParamFromUrl('oponentes'))
    .then((response) => {
      setNomeOponentes(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

    processosData.oponente = getParamFromUrl('oponentes');
  }
}

if (getParamFromUrl('area') > 0) {
  if (processosData.id === 0 && processosData.area == 0) {
    areaApi
    .getById(getParamFromUrl('area'))
    .then((response) => {
      setNomeArea(response.data.descricao);
    })
    .catch((error) => {
      console.error(error);
    });

    processosData.area = getParamFromUrl('area');
  }
}

if (getParamFromUrl('cidade') > 0) {
  if (processosData.id === 0 && processosData.cidade == 0) {
    cidadeApi
    .getById(getParamFromUrl('cidade'))
    .then((response) => {
      setNomeCidade(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

    processosData.cidade = getParamFromUrl('cidade');
  }
}

if (getParamFromUrl('situacao') > 0) {
  if (processosData.id === 0 && processosData.situacao == 0) {
    situacaoApi
    .getById(getParamFromUrl('situacao'))
    .then((response) => {
      setNomeSituacao(response.data.campo);
    })
    .catch((error) => {
      console.error(error);
    });

    processosData.situacao = getParamFromUrl('situacao');
  }
}

if (getParamFromUrl('rito') > 0) {
  if (processosData.id === 0 && processosData.rito == 0) {
    ritoApi
    .getById(getParamFromUrl('rito'))
    .then((response) => {
      setNomeRito(response.data.descricao);
    })
    .catch((error) => {
      console.error(error);
    });

    processosData.rito = getParamFromUrl('rito');
  }
}

if (getParamFromUrl('atividades') > 0) {
  if (processosData.id === 0 && processosData.atividade == 0) {
    atividadesApi
    .getById(getParamFromUrl('atividades'))
    .then((response) => {
      setNomeAtividades(response.data.descricao);
    })
    .catch((error) => {
      console.error(error);
    });

    processosData.atividade = getParamFromUrl('atividades');
  }
}
const addValorAdvOpo = (e: any) => {
  if (e?.id>0)
    processosData.advopo = e.id;
  };
  const addValorJustica = (e: any) => {
    if (e?.id>0)
      processosData.justica = e.id;
    };
    const addValorAdvogado = (e: any) => {
      if (e?.id>0)
        processosData.advogado = e.id;
      };
      const addValorPreposto = (e: any) => {
        if (e?.id>0)
          processosData.preposto = e.id;
        };
        const addValorCliente = (e: any) => {
          if (e?.id>0)
            processosData.cliente = e.id;
          };
          const addValorOponente = (e: any) => {
            if (e?.id>0)
              processosData.oponente = e.id;
            };
            const addValorArea = (e: any) => {
              if (e?.id>0)
                processosData.area = e.id;
              };
              const addValorCidade = (e: any) => {
                if (e?.id>0)
                  processosData.cidade = e.id;
                };
                const addValorSituacao = (e: any) => {
                  if (e?.id>0)
                    processosData.situacao = e.id;
                  };
                  const addValorRito = (e: any) => {
                    if (e?.id>0)
                      processosData.rito = e.id;
                    };
                    const addValorAtividade = (e: any) => {
                      if (e?.id>0)
                        processosData.atividade = e.id;
                      };
                      const onConfirm = (e: React.FormEvent) => {
                        e.preventDefault();
                        if (e.stopPropagation) e.stopPropagation();

                          if (!isSubmitting) {
                            setIsSubmitting(true);

                            try {
                              onSubmit(e);
                            } catch (error) {
                            console.error('Erro ao submeter formulário de Processos:', error);
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
                              target: document.getElementById(`ProcessosForm-${processosData.id}`)
                            } as unknown as React.FormEvent;

                            onSubmit(syntheticEvent);
                          } catch (error) {
                          console.error('Erro ao salvar Processos diretamente:', error);
                          setIsSubmitting(false);
                          if (onError) onError();
                          }
                        }
                      };
                      useEffect(() => {
                        const el = document.querySelector('.nameFormMobile');
                        if (el) {
                          el.textContent = processosData?.id == 0 ? 'Editar Processos' : 'Adicionar Processos';
                        }
                      }, [processosData.id]);
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

                        <div className={isMobile ? 'form-container form-container-Processos' : 'form-container form-container-Processos'}>

                          <form className='formInputCadInc' id={`ProcessosForm-${processosData.id}`} onSubmit={onConfirm}>
                            {!isMobile && (
                              <ButtonSalvarCrud isMobile={false} validationForm={validationForm} entity='Processos' data={processosData} isSubmitting={isSubmitting} onClose={onClose} formId={`ProcessosForm-${processosData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
                              )}
                              <div className='grid-container'>

                                <InputName
                                type='text'
                                id='nropasta'
                                label='NroPasta'
                                dataForm={processosData}
                                className='inputIncNome'
                                name='nropasta'
                                value={processosData.nropasta}
                                placeholder={`Informe NroPasta`}
                                onChange={onChange}
                                required
                                />

                                <InputInput
                                type='text'
                                maxLength={2048}
                                id='advparc'
                                label='AdvParc'
                                dataForm={processosData}
                                className='inputIncNome'
                                name='advparc'
                                value={processosData.advparc}
                                onChange={onChange}
                                />

                                <InputCheckbox dataForm={processosData} label='AJGPedidoNegado' name='ajgpedidonegado' checked={processosData.ajgpedidonegado} onChange={onChange} />
                                <InputCheckbox dataForm={processosData} label='AJGCliente' name='ajgcliente' checked={processosData.ajgcliente} onChange={onChange} />
                                <InputCheckbox dataForm={processosData} label='AJGPedidoNegadoOPO' name='ajgpedidonegadoopo' checked={processosData.ajgpedidonegadoopo} onChange={onChange} />
                                <InputCheckbox dataForm={processosData} label='NotificarPOE' name='notificarpoe' checked={processosData.notificarpoe} onChange={onChange} />

                                <InputInput
                                type='text'
                                maxLength={2048}
                                id='valorprovisionado'
                                label='ValorProvisionado'
                                dataForm={processosData}
                                className='inputIncNome'
                                name='valorprovisionado'
                                value={processosData.valorprovisionado}
                                onChange={onChange}
                                />

                                <InputCheckbox dataForm={processosData} label='AJGOponente' name='ajgoponente' checked={processosData.ajgoponente} onChange={onChange} />

                                <InputInput
                                type='text'
                                maxLength={2048}
                                id='valorcachecalculo'
                                label='ValorCacheCalculo'
                                dataForm={processosData}
                                className='inputIncNome'
                                name='valorcachecalculo'
                                value={processosData.valorcachecalculo}
                                onChange={onChange}
                                />

                                <InputCheckbox dataForm={processosData} label='AJGPedidoOPO' name='ajgpedidoopo' checked={processosData.ajgpedidoopo} onChange={onChange} />
                              </div><div className='grid-container'>
                                <InputInput
                                type='text'
                                maxLength={2048}
                                id='valorcachecalculoprov'
                                label='ValorCacheCalculoProv'
                                dataForm={processosData}
                                className='inputIncNome'
                                name='valorcachecalculoprov'
                                value={processosData.valorcachecalculoprov}
                                onChange={onChange}
                                />

                                <InputCheckbox dataForm={processosData} label='ConsiderarParado' name='considerarparado' checked={processosData.considerarparado} onChange={onChange} />
                                <InputCheckbox dataForm={processosData} label='ValorCalculado' name='valorcalculado' checked={processosData.valorcalculado} onChange={onChange} />
                                <InputCheckbox dataForm={processosData} label='AJGConcedidoOPO' name='ajgconcedidoopo' checked={processosData.ajgconcedidoopo} onChange={onChange} />
                                <InputCheckbox dataForm={processosData} label='Cobranca' name='cobranca' checked={processosData.cobranca} onChange={onChange} />

                                <InputInput
                                type='text'
                                maxLength={2048}
                                id='dataentrada'
                                label='DataEntrada'
                                dataForm={processosData}
                                className='inputIncNome'
                                name='dataentrada'
                                value={processosData.dataentrada}
                                onChange={onChange}
                                />

                                <InputCheckbox dataForm={processosData} label='Penhora' name='penhora' checked={processosData.penhora} onChange={onChange} />
                                <InputCheckbox dataForm={processosData} label='AJGPedido' name='ajgpedido' checked={processosData.ajgpedido} onChange={onChange} />

                                <InputInput
                                type='text'
                                maxLength={2048}
                                id='tipobaixa'
                                label='TipoBaixa'
                                dataForm={processosData}
                                className='inputIncNome'
                                name='tipobaixa'
                                value={processosData.tipobaixa}
                                onChange={onChange}
                                />


                                <InputInput
                                type='text'
                                maxLength={2048}
                                id='classrisco'
                                label='ClassRisco'
                                dataForm={processosData}
                                className='inputIncNome'
                                name='classrisco'
                                value={processosData.classrisco}
                                onChange={onChange}
                                />

                              </div><div className='grid-container'><InputCheckbox dataForm={processosData} label='IsApenso' name='isapenso' checked={processosData.isapenso} onChange={onChange} />

                              <InputInput
                              type='text'
                              maxLength={2048}
                              id='valorcausainicial'
                              label='ValorCausaInicial'
                              dataForm={processosData}
                              className='inputIncNome'
                              name='valorcausainicial'
                              value={processosData.valorcausainicial}
                              onChange={onChange}
                              />

                              <InputCheckbox dataForm={processosData} label='AJGConcedido' name='ajgconcedido' checked={processosData.ajgconcedido} onChange={onChange} />

                              <InputInput
                              type='text'
                              maxLength={2147483647}
                              id='obsbcx'
                              label='ObsBCX'
                              dataForm={processosData}
                              className='inputIncNome'
                              name='obsbcx'
                              value={processosData.obsbcx}
                              onChange={onChange}
                              />


                              <InputInput
                              type='text'
                              maxLength={2048}
                              id='valorcausadefinitivo'
                              label='ValorCausaDefinitivo'
                              dataForm={processosData}
                              className='inputIncNome'
                              name='valorcausadefinitivo'
                              value={processosData.valorcausadefinitivo}
                              onChange={onChange}
                              />


                              <InputInput
                              type='text'
                              maxLength={2048}
                              id='percprobexito'
                              label='PercProbExito'
                              dataForm={processosData}
                              className='inputIncNome'
                              name='percprobexito'
                              value={processosData.percprobexito}
                              onChange={onChange}
                              />

                              <InputCheckbox dataForm={processosData} label='MNA' name='mna' checked={processosData.mna} onChange={onChange} />

                              <InputInput
                              type='text'
                              maxLength={2048}
                              id='percexito'
                              label='PercExito'
                              dataForm={processosData}
                              className='inputIncNome'
                              name='percexito'
                              value={processosData.percexito}
                              onChange={onChange}
                              />


                              <InputInput
                              type='text'
                              maxLength={35}
                              id='nroextra'
                              label='NroExtra'
                              dataForm={processosData}
                              className='inputIncNome'
                              name='nroextra'
                              value={processosData.nroextra}
                              onChange={onChange}
                              />


                              <AdvogadosComboBox
                              name={'advopo'}
                              dataForm={processosData}
                              value={processosData.advopo}
                              setValue={addValorAdvOpo}
                              label={'Advogados'}
                              />
                            </div><div className='grid-container'><InputCheckbox dataForm={processosData} label='Extra' name='extra' checked={processosData.extra} onChange={onChange} />

                            <JusticaComboBox
                            name={'justica'}
                            dataForm={processosData}
                            value={processosData.justica}
                            setValue={addValorJustica}
                            label={'Justica'}
                            />

                            <AdvogadosComboBox
                            name={'advogado'}
                            dataForm={processosData}
                            value={processosData.advogado}
                            setValue={addValorAdvogado}
                            label={'Advogados'}
                            />

                            <InputInput
                            type='text'
                            maxLength={20}
                            id='nrocaixa'
                            label='NroCaixa'
                            dataForm={processosData}
                            className='inputIncNome'
                            name='nrocaixa'
                            value={processosData.nrocaixa}
                            onChange={onChange}
                            />


                            <PrepostosComboBox
                            name={'preposto'}
                            dataForm={processosData}
                            value={processosData.preposto}
                            setValue={addValorPreposto}
                            label={'Prepostos'}
                            />

                            <ClientesComboBox
                            name={'cliente'}
                            dataForm={processosData}
                            value={processosData.cliente}
                            setValue={addValorCliente}
                            label={'Clientes'}
                            />

                            <OponentesComboBox
                            name={'oponente'}
                            dataForm={processosData}
                            value={processosData.oponente}
                            setValue={addValorOponente}
                            label={'Oponentes'}
                            />

                            <AreaComboBox
                            name={'area'}
                            dataForm={processosData}
                            value={processosData.area}
                            setValue={addValorArea}
                            label={'Area'}
                            />

                            <CidadeComboBox
                            name={'cidade'}
                            dataForm={processosData}
                            value={processosData.cidade}
                            setValue={addValorCidade}
                            label={'Cidade'}
                            />

                            <SituacaoComboBox
                            name={'situacao'}
                            dataForm={processosData}
                            value={processosData.situacao}
                            setValue={addValorSituacao}
                            label={'Situacao'}
                            />
                          </div><div className='grid-container'><InputCheckbox dataForm={processosData} label='IDSituacao' name='idsituacao' checked={processosData.idsituacao} onChange={onChange} />

                          <InputInput
                          type='text'
                          maxLength={2048}
                          id='valor'
                          label='Valor'
                          dataForm={processosData}
                          className='inputIncNome'
                          name='valor'
                          value={processosData.valor}
                          onChange={onChange}
                          />


                          <RitoComboBox
                          name={'rito'}
                          dataForm={processosData}
                          value={processosData.rito}
                          setValue={addValorRito}
                          label={'Rito'}
                          />

                          <InputInput
                          type='text'
                          maxLength={2147483647}
                          id='fato'
                          label='Fato'
                          dataForm={processosData}
                          className='inputIncNome'
                          name='fato'
                          value={processosData.fato}
                          onChange={onChange}
                          />


                          <AtividadesComboBox
                          name={'atividade'}
                          dataForm={processosData}
                          value={processosData.atividade}
                          setValue={addValorAtividade}
                          label={'Atividades'}
                          />

                          <InputInput
                          type='text'
                          maxLength={10}
                          id='caixamorto'
                          label='CaixaMorto'
                          dataForm={processosData}
                          className='inputIncNome'
                          name='caixamorto'
                          value={processosData.caixamorto}
                          onChange={onChange}
                          />

                          <InputCheckbox dataForm={processosData} label='Baixado' name='baixado' checked={processosData.baixado} onChange={onChange} />

                          <InputInput
                          type='text'
                          maxLength={2048}
                          id='dtbaixa'
                          label='DtBaixa'
                          dataForm={processosData}
                          className='inputIncNome'
                          name='dtbaixa'
                          value={processosData.dtbaixa}
                          onChange={onChange}
                          />


                          <InputInput
                          type='text'
                          maxLength={2147483647}
                          id='motivobaixa'
                          label='MotivoBaixa'
                          dataForm={processosData}
                          className='inputIncNome'
                          name='motivobaixa'
                          value={processosData.motivobaixa}
                          onChange={onChange}
                          />


                          <InputInput
                          type='text'
                          maxLength={2147483647}
                          id='obs'
                          label='OBS'
                          dataForm={processosData}
                          className='inputIncNome'
                          name='obs'
                          value={processosData.obs}
                          onChange={onChange}
                          />

                        </div><div className='grid-container'><InputCheckbox dataForm={processosData} label='Printed' name='printed' checked={processosData.printed} onChange={onChange} />

                        <InputInput
                        type='text'
                        maxLength={20}
                        id='zkey'
                        label='ZKey'
                        dataForm={processosData}
                        className='inputIncNome'
                        name='zkey'
                        value={processosData.zkey}
                        onChange={onChange}
                        />


                        <InputInput
                        type='text'
                        maxLength={2048}
                        id='zkeyquem'
                        label='ZKeyQuem'
                        dataForm={processosData}
                        className='inputIncNome'
                        name='zkeyquem'
                        value={processosData.zkeyquem}
                        onChange={onChange}
                        />


                        <InputInput
                        type='text'
                        maxLength={2048}
                        id='zkeyquando'
                        label='ZKeyQuando'
                        dataForm={processosData}
                        className='inputIncNome'
                        name='zkeyquando'
                        value={processosData.zkeyquando}
                        onChange={onChange}
                        />


                        <InputInput
                        type='text'
                        maxLength={2147483647}
                        id='resumo'
                        label='Resumo'
                        dataForm={processosData}
                        className='inputIncNome'
                        name='resumo'
                        value={processosData.resumo}
                        onChange={onChange}
                        />

                        <InputCheckbox dataForm={processosData} label='NaoImprimir' name='naoimprimir' checked={processosData.naoimprimir} onChange={onChange} />
                        <InputCheckbox dataForm={processosData} label='Eletronico' name='eletronico' checked={processosData.eletronico} onChange={onChange} />

                        <InputInput
                        type='text'
                        maxLength={100}
                        id='nrocontrato'
                        label='NroContrato'
                        dataForm={processosData}
                        className='inputIncNome'
                        name='nrocontrato'
                        value={processosData.nrocontrato}
                        onChange={onChange}
                        />


                        <InputInput
                        type='text'
                        maxLength={1024}
                        id='percprobexitojustificativa'
                        label='PercProbExitoJustificativa'
                        dataForm={processosData}
                        className='inputIncNome'
                        name='percprobexitojustificativa'
                        value={processosData.percprobexitojustificativa}
                        onChange={onChange}
                        />


                        <InputInput
                        type='text'
                        maxLength={2048}
                        id='honorariovalor'
                        label='HonorarioValor'
                        dataForm={processosData}
                        className='inputIncNome'
                        name='honorariovalor'
                        value={processosData.honorariovalor}
                        onChange={onChange}
                        />

                      </div><div className='grid-container'>
                        <InputInput
                        type='text'
                        maxLength={2048}
                        id='honorariopercentual'
                        label='HonorarioPercentual'
                        dataForm={processosData}
                        className='inputIncNome'
                        name='honorariopercentual'
                        value={processosData.honorariopercentual}
                        onChange={onChange}
                        />


                        <InputInput
                        type='text'
                        maxLength={2048}
                        id='honorariosucumbencia'
                        label='HonorarioSucumbencia'
                        dataForm={processosData}
                        className='inputIncNome'
                        name='honorariosucumbencia'
                        value={processosData.honorariosucumbencia}
                        onChange={onChange}
                        />


                        <InputInput
                        type='text'
                        maxLength={2048}
                        id='faseauditoria'
                        label='FaseAuditoria'
                        dataForm={processosData}
                        className='inputIncNome'
                        name='faseauditoria'
                        value={processosData.faseauditoria}
                        onChange={onChange}
                        />


                        <InputInput
                        type='text'
                        maxLength={2048}
                        id='valorcondenacao'
                        label='ValorCondenacao'
                        dataForm={processosData}
                        className='inputIncNome'
                        name='valorcondenacao'
                        value={processosData.valorcondenacao}
                        onChange={onChange}
                        />


                        <InputInput
                        type='text'
                        maxLength={2048}
                        id='valorcondenacaocalculado'
                        label='ValorCondenacaoCalculado'
                        dataForm={processosData}
                        className='inputIncNome'
                        name='valorcondenacaocalculado'
                        value={processosData.valorcondenacaocalculado}
                        onChange={onChange}
                        />


                        <InputInput
                        type='text'
                        maxLength={2048}
                        id='valorcondenacaoprovisorio'
                        label='ValorCondenacaoProvisorio'
                        dataForm={processosData}
                        className='inputIncNome'
                        name='valorcondenacaoprovisorio'
                        value={processosData.valorcondenacaoprovisorio}
                        onChange={onChange}
                        />

                      </div>
                    </form>


                    {isMobile && (
                      <ButtonSalvarCrud isMobile={true} validationForm={validationForm} entity='Processos' data={processosData} isSubmitting={isSubmitting} onClose={onClose} formId={`ProcessosForm-${processosData.id}`} preventPropagation={true} onSave={handleDirectSave} onCancel={handleCancel} />
                      )}
                      <DeleteButton page={'/pages/processos'} id={processosData.id} closeModel={onClose} dadoApi={dadoApi} />
                    </div>
                    <div className='form-spacer'></div>
                    </>
                  );
                };