"use client";
import { Button, Checkbox, Input } from '@progress/kendo-react-all';
import { IContratos } from '../../Interfaces/interface.Contratos';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudForms.css'; // [ INDEX_SIZE ]
import { useIsMobile } from '@/app/context/MobileContext';

import ProcessosComboBox from '@/app/GerAdv_TS/Processos/ComboBox/Processos';
import ClientesComboBox from '@/app/GerAdv_TS/Clientes/ComboBox/Clientes';
import AdvogadosComboBox from '@/app/GerAdv_TS/Advogados/ComboBox/Advogados';
import { ProcessosApi } from '@/app/GerAdv_TS/Processos/Apis/ApiProcessos';
import { ClientesApi } from '@/app/GerAdv_TS/Clientes/Apis/ApiClientes';
import { AdvogadosApi } from '@/app/GerAdv_TS/Advogados/Apis/ApiAdvogados';

interface ContratosFormProps {
    contratosData: IContratos;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const ContratosForm: React.FC<ContratosFormProps> = ({
    contratosData,
    onChange,
    onSubmit,
    onClose,
    onError,
  }) => {

  const router = useRouter(); 
  const { systemContext } = useSystemContext();
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [nomeProcessos, setNomeProcessos] = useState('');
            const processosApi = new ProcessosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeClientes, setNomeClientes] = useState('');
            const clientesApi = new ClientesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeAdvogados, setNomeAdvogados] = useState('');
            const advogadosApi = new AdvogadosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
 
if (getParamFromUrl("processos") > 0) {
  processosApi
    .getById(getParamFromUrl("processos"))
    .then((response) => {
      setNomeProcessos(response.data.nropasta);
    })
    .catch((error) => {
      console.error(error);
    });

  if (contratosData.id === 0) {
    contratosData.processo = getParamFromUrl("processos");
  }
}
 
if (getParamFromUrl("clientes") > 0) {
  clientesApi
    .getById(getParamFromUrl("clientes"))
    .then((response) => {
      setNomeClientes(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (contratosData.id === 0) {
    contratosData.cliente = getParamFromUrl("clientes");
  }
}
 
if (getParamFromUrl("advogados") > 0) {
  advogadosApi
    .getById(getParamFromUrl("advogados"))
    .then((response) => {
      setNomeAdvogados(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (contratosData.id === 0) {
    contratosData.advogado = getParamFromUrl("advogados");
  }
}
 const addValorProcesso = (e: any) => {
                        if (e?.id>0)
                        contratosData.processo = e.id;
                      };
 const addValorCliente = (e: any) => {
                        if (e?.id>0)
                        contratosData.cliente = e.id;
                      };
 const addValorAdvogado = (e: any) => {
                        if (e?.id>0)
                        contratosData.advogado = e.id;
                      };

  const onConfirm = (e: React.FormEvent) => {
    e.preventDefault();
    if (!isSubmitting) {
      setIsSubmitting(true);
      onSubmit(e);
    }
   };

  return (
  <>
  {nomeProcessos && (<h2>{nomeProcessos}</h2>)}
{nomeClientes && (<h2>{nomeClientes}</h2>)}
{nomeAdvogados && (<h2>{nomeAdvogados}</h2>)}

    <div className="form-container">
       
        <form onSubmit={onConfirm}>
         
         <div className="grid-container">

            <ProcessosComboBox
            name={'processo'}
            value={contratosData.processo}
            setValue={addValorProcesso}
            label={'Processos'}
            />

            <ClientesComboBox
            name={'cliente'}
            value={contratosData.cliente}
            setValue={addValorCliente}
            label={'Clientes'}
            />

            <AdvogadosComboBox
            name={'advogado'}
            value={contratosData.advogado}
            setValue={addValorAdvogado}
            label={'Advogados'}
            />

<Input
type="text"
id="dia"
label="Dia"
className="inputIncNome"
name="dia"
value={contratosData.dia}
onChange={onChange}               
/>

<Input
type="text"
id="valor"
label="Valor"
className="inputIncNome"
name="valor"
value={contratosData.valor}
onChange={onChange}               
/>

<Input
type="text"
id="datainicio"
label="DataInicio"
className="inputIncNome"
name="datainicio"
value={contratosData.datainicio}
onChange={onChange}               
/>

<Input
type="text"
id="datatermino"
label="DataTermino"
className="inputIncNome"
name="datatermino"
value={contratosData.datatermino}
onChange={onChange}               
/>

<Checkbox label="OcultarRelatorio" name="ocultarrelatorio" checked={contratosData.ocultarrelatorio} onChange={onChange} />
        
<Input
type="text"
id="percescritorio"
label="PercEscritorio"
className="inputIncNome"
name="percescritorio"
value={contratosData.percescritorio}
onChange={onChange}               
/>

</div><div className="grid-container">        
<Input
type="text"
id="valorconsultoria"
label="ValorConsultoria"
className="inputIncNome"
name="valorconsultoria"
value={contratosData.valorconsultoria}
onChange={onChange}               
/>

<Input
type="text"
id="tipocobranca"
label="TipoCobranca"
className="inputIncNome"
name="tipocobranca"
value={contratosData.tipocobranca}
onChange={onChange}               
/>

<Input
type="text"
id="protestar"
label="Protestar"
className="inputIncNome"
name="protestar"
value={contratosData.protestar}
onChange={onChange}               
/>

<Input
type="text"
id="juros"
label="Juros"
className="inputIncNome"
name="juros"
value={contratosData.juros}
onChange={onChange}               
/>

<Input
type="text"
id="valorrealizavel"
label="ValorRealizavel"
className="inputIncNome"
name="valorrealizavel"
value={contratosData.valorrealizavel}
onChange={onChange}               
/>

<Input
type="text"
id="documento"
label="DOCUMENTO"
className="inputIncNome"
name="documento"
value={contratosData.documento}
onChange={onChange}               
/>

<Input
type="email"
id="email1"
label="EMail1"
className="inputIncNome"
name="email1"
value={contratosData.email1}
onChange={onChange}               
/>

<Input
type="email"
id="email2"
label="EMail2"
className="inputIncNome"
name="email2"
value={contratosData.email2}
onChange={onChange}               
/>

<Input
type="email"
id="email3"
label="EMail3"
className="inputIncNome"
name="email3"
value={contratosData.email3}
onChange={onChange}               
/>

<Input
type="text"
id="pessoa1"
label="Pessoa1"
className="inputIncNome"
name="pessoa1"
value={contratosData.pessoa1}
onChange={onChange}               
/>

</div><div className="grid-container">        
<Input
type="text"
id="pessoa2"
label="Pessoa2"
className="inputIncNome"
name="pessoa2"
value={contratosData.pessoa2}
onChange={onChange}               
/>

<Input
type="text"
id="pessoa3"
label="Pessoa3"
className="inputIncNome"
name="pessoa3"
value={contratosData.pessoa3}
onChange={onChange}               
/>

<Input
type="text"
id="obs"
label="OBS"
className="inputIncNome"
name="obs"
value={contratosData.obs}
onChange={onChange}               
/>

<Input
type="text"
id="clientecontrato"
label="ClienteContrato"
className="inputIncNome"
name="clientecontrato"
value={contratosData.clientecontrato}
onChange={onChange}               
/>

<Input
type="text"
id="idextrangeiro"
label="IdExtrangeiro"
className="inputIncNome"
name="idextrangeiro"
value={contratosData.idextrangeiro}
onChange={onChange}               
/>

<Input
type="text"
id="chavecontrato"
label="ChaveContrato"
className="inputIncNome"
name="chavecontrato"
value={contratosData.chavecontrato}
onChange={onChange}               
/>

<Checkbox label="Avulso" name="avulso" checked={contratosData.avulso} onChange={onChange} />
<Checkbox label="Suspenso" name="suspenso" checked={contratosData.suspenso} onChange={onChange} />
        
<Input
type="text"
id="multa"
label="Multa"
className="inputIncNome"
name="multa"
value={contratosData.multa}
onChange={onChange}               
/>

          </div>
           <div className="buttons-container">
              <br />
              <Button type="button" className="buttonSair" onClick={onClose}>
                Cancelar
              </Button>
              &nbsp;&nbsp;
              <Button type="submit" themeColor="primary" className="buttonOk" disabled={isSubmitting}>
                Salvar
              </Button>
          </div>
        </form>
    </div>
    </>
     );
};
 