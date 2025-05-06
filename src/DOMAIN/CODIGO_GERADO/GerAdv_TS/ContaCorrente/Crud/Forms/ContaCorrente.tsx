// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IContaCorrente } from '@/app/GerAdv_TS/ContaCorrente/Interfaces/interface.ContaCorrente';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudFormsBase.css';
import '@/app/styles/Inputs.css';
import '@/app/styles/CrudForms.css'; // [ INDEX_SIZE ]
import ButtonsCrud from '@/app/components/Cruds/ButtonsCrud';
import { useIsMobile } from '@/app/context/MobileContext';

import ProcessosComboBox from '@/app/GerAdv_TS/Processos/ComboBox/Processos';
import ClientesComboBox from '@/app/GerAdv_TS/Clientes/ComboBox/Clientes';
import { ProcessosApi } from '@/app/GerAdv_TS/Processos/Apis/ApiProcessos';
import { ClientesApi } from '@/app/GerAdv_TS/Clientes/Apis/ApiClientes';
import InputName from '@/app/components/Inputs/InputName';
import InputCheckbox from '@/app/components/Inputs/InputCheckbox';

interface ContaCorrenteFormProps {
    contacorrenteData: IContaCorrente;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const ContaCorrenteForm: React.FC<ContaCorrenteFormProps> = ({
    contacorrenteData,
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
 
if (getParamFromUrl("processos") > 0) {
  processosApi
    .getById(getParamFromUrl("processos"))
    .then((response) => {
      setNomeProcessos(response.data.nropasta);
    })
    .catch((error) => {
      console.error(error);
    });

  if (contacorrenteData.id === 0) {
    contacorrenteData.processo = getParamFromUrl("processos");
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

  if (contacorrenteData.id === 0) {
    contacorrenteData.cliente = getParamFromUrl("clientes");
  }
}
 const addValorProcesso = (e: any) => {
                        if (e?.id>0)
                        contacorrenteData.processo = e.id;
                      };
 const addValorCliente = (e: any) => {
                        if (e?.id>0)
                        contacorrenteData.cliente = e.id;
                      };

  const onConfirm = (e: React.FormEvent) => {
    e.preventDefault();
    if (!isSubmitting) {
      setIsSubmitting(true);
      onSubmit(e);
    }
   };

  const onPressSalvar = (e: any) => {
    e.preventDefault();
    if (!isSubmitting) {
      const formElement = document.getElementById('ContaCorrenteForm');

      if (formElement) {
        const syntheticEvent = new Event('submit', { bubbles: true, cancelable: true });
        formElement.dispatchEvent(syntheticEvent);
      }
    }
  };

  return (
  <>
  
        <div className="form-container">
       
            <form id={`ContaCorrenteForm-${contacorrenteData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={contacorrenteData} isSubmitting={isSubmitting} onClose={onClose} formId={`ContaCorrenteForm-${contacorrenteData.id}`} />

                <div className="grid-container">

<Input
type="text"
id="ciacordo"
label="CIAcordo"
className="inputIncNome"
name="ciacordo"
value={contacorrenteData.ciacordo}
onChange={onChange}               
/>

<InputCheckbox label="Quitado" name="quitado" checked={contacorrenteData.quitado} onChange={onChange} />
        
<Input
type="text"
id="idcontrato"
label="IDContrato"
className="inputIncNome"
name="idcontrato"
value={contacorrenteData.idcontrato}
onChange={onChange}               
/>

<Input
type="text"
id="quitadoid"
label="QuitadoID"
className="inputIncNome"
name="quitadoid"
value={contacorrenteData.quitadoid}
onChange={onChange}               
/>

<Input
type="text"
id="debitoid"
label="DebitoID"
className="inputIncNome"
name="debitoid"
value={contacorrenteData.debitoid}
onChange={onChange}               
/>

<Input
type="text"
id="livrocaixaid"
label="LivroCaixaID"
className="inputIncNome"
name="livrocaixaid"
value={contacorrenteData.livrocaixaid}
onChange={onChange}               
/>

<InputCheckbox label="Sucumbencia" name="sucumbencia" checked={contacorrenteData.sucumbencia} onChange={onChange} />
<InputCheckbox label="DistRegra" name="distregra" checked={contacorrenteData.distregra} onChange={onChange} />
        
<Input
type="text"
id="dtoriginal"
label="DtOriginal"
className="inputIncNome"
name="dtoriginal"
value={contacorrenteData.dtoriginal}
onChange={onChange}               
/>

</div><div className="grid-container"> 
            <ProcessosComboBox
            name={'processo'}
            value={contacorrenteData.processo}
            setValue={addValorProcesso}
            label={'Processos'}
            />

<Input
type="text"
id="parcelax"
label="ParcelaX"
className="inputIncNome"
name="parcelax"
value={contacorrenteData.parcelax}
onChange={onChange}               
/>

<Input
type="text"
id="valor"
label="Valor"
className="inputIncNome"
name="valor"
value={contacorrenteData.valor}
onChange={onChange}               
/>

<Input
type="text"
id="data"
label="Data"
className="inputIncNome"
name="data"
value={contacorrenteData.data}
onChange={onChange}               
/>

            <ClientesComboBox
            name={'cliente'}
            value={contacorrenteData.cliente}
            setValue={addValorCliente}
            label={'Clientes'}
            />

<Input
type="text"
id="historico"
label="Historico"
className="inputIncNome"
name="historico"
value={contacorrenteData.historico}
onChange={onChange}               
/>

<InputCheckbox label="Contrato" name="contrato" checked={contacorrenteData.contrato} onChange={onChange} />
<InputCheckbox label="Pago" name="pago" checked={contacorrenteData.pago} onChange={onChange} />
<InputCheckbox label="Distribuir" name="distribuir" checked={contacorrenteData.distribuir} onChange={onChange} />
<InputCheckbox label="LC" name="lc" checked={contacorrenteData.lc} onChange={onChange} />
</div><div className="grid-container">        
<Input
type="text"
id="idhtrab"
label="IDHTrab"
className="inputIncNome"
name="idhtrab"
value={contacorrenteData.idhtrab}
onChange={onChange}               
/>

<Input
type="text"
id="nroparcelas"
label="NroParcelas"
className="inputIncNome"
name="nroparcelas"
value={contacorrenteData.nroparcelas}
onChange={onChange}               
/>

<Input
type="text"
id="valorprincipal"
label="ValorPrincipal"
className="inputIncNome"
name="valorprincipal"
value={contacorrenteData.valorprincipal}
onChange={onChange}               
/>

<Input
type="text"
id="parcelaprincipalid"
label="ParcelaPrincipalID"
className="inputIncNome"
name="parcelaprincipalid"
value={contacorrenteData.parcelaprincipalid}
onChange={onChange}               
/>

<InputCheckbox label="Hide" name="hide" checked={contacorrenteData.hide} onChange={onChange} />
        
<Input
type="text"
id="datapgto"
label="DataPgto"
className="inputIncNome"
name="datapgto"
value={contacorrenteData.datapgto}
onChange={onChange}               
/>

                </div>               
            </form>
        </div>
        
    </>
     );
};
 