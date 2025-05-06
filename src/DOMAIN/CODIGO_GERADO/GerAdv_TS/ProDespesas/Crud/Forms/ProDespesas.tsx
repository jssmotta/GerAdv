// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IProDespesas } from '@/app/GerAdv_TS/ProDespesas/Interfaces/interface.ProDespesas';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudFormsBase.css';
import '@/app/styles/Inputs.css';
import '@/app/styles/CrudForms.css'; // [ INDEX_SIZE ]
import ButtonsCrud from '@/app/components/Cruds/ButtonsCrud';
import { useIsMobile } from '@/app/context/MobileContext';

import ClientesComboBox from '@/app/GerAdv_TS/Clientes/ComboBox/Clientes';
import ProcessosComboBox from '@/app/GerAdv_TS/Processos/ComboBox/Processos';
import { ClientesApi } from '@/app/GerAdv_TS/Clientes/Apis/ApiClientes';
import { ProcessosApi } from '@/app/GerAdv_TS/Processos/Apis/ApiProcessos';
import InputName from '@/app/components/Inputs/InputName';
import InputCheckbox from '@/app/components/Inputs/InputCheckbox';

interface ProDespesasFormProps {
    prodespesasData: IProDespesas;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const ProDespesasForm: React.FC<ProDespesasFormProps> = ({
    prodespesasData,
    onChange,
    onSubmit,
    onClose,
    onError,
  }) => {

  const router = useRouter(); 
  const { systemContext } = useSystemContext();
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [nomeClientes, setNomeClientes] = useState('');
            const clientesApi = new ClientesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
const [nomeProcessos, setNomeProcessos] = useState('');
            const processosApi = new ProcessosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
 
if (getParamFromUrl("clientes") > 0) {
  clientesApi
    .getById(getParamFromUrl("clientes"))
    .then((response) => {
      setNomeClientes(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (prodespesasData.id === 0) {
    prodespesasData.cliente = getParamFromUrl("clientes");
  }
}
 
if (getParamFromUrl("processos") > 0) {
  processosApi
    .getById(getParamFromUrl("processos"))
    .then((response) => {
      setNomeProcessos(response.data.nropasta);
    })
    .catch((error) => {
      console.error(error);
    });

  if (prodespesasData.id === 0) {
    prodespesasData.processo = getParamFromUrl("processos");
  }
}
 const addValorCliente = (e: any) => {
                        if (e?.id>0)
                        prodespesasData.cliente = e.id;
                      };
 const addValorProcesso = (e: any) => {
                        if (e?.id>0)
                        prodespesasData.processo = e.id;
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
      const formElement = document.getElementById('ProDespesasForm');

      if (formElement) {
        const syntheticEvent = new Event('submit', { bubbles: true, cancelable: true });
        formElement.dispatchEvent(syntheticEvent);
      }
    }
  };

  return (
  <>
  
        <div className="form-container">
       
            <form id={`ProDespesasForm-${prodespesasData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={prodespesasData} isSubmitting={isSubmitting} onClose={onClose} formId={`ProDespesasForm-${prodespesasData.id}`} />

                <div className="grid-container">

<Input
type="text"
id="ligacaoid"
label="LigacaoID"
className="inputIncNome"
name="ligacaoid"
value={prodespesasData.ligacaoid}
onChange={onChange}               
/>

            <ClientesComboBox
            name={'cliente'}
            value={prodespesasData.cliente}
            setValue={addValorCliente}
            label={'Clientes'}
            />

<InputCheckbox label="Corrigido" name="corrigido" checked={prodespesasData.corrigido} onChange={onChange} />
        
<Input
type="text"
id="data"
label="Data"
className="inputIncNome"
name="data"
value={prodespesasData.data}
onChange={onChange}               
/>

<Input
type="text"
id="valororiginal"
label="ValorOriginal"
className="inputIncNome"
name="valororiginal"
value={prodespesasData.valororiginal}
onChange={onChange}               
/>

            <ProcessosComboBox
            name={'processo'}
            value={prodespesasData.processo}
            setValue={addValorProcesso}
            label={'Processos'}
            />

<Input
type="text"
id="quitado"
label="Quitado"
className="inputIncNome"
name="quitado"
value={prodespesasData.quitado}
onChange={onChange}               
/>

<Input
type="text"
id="datacorrecao"
label="DataCorrecao"
className="inputIncNome"
name="datacorrecao"
value={prodespesasData.datacorrecao}
onChange={onChange}               
/>

<Input
type="text"
id="valor"
label="Valor"
className="inputIncNome"
name="valor"
value={prodespesasData.valor}
onChange={onChange}               
/>

</div><div className="grid-container"><InputCheckbox label="Tipo" name="tipo" checked={prodespesasData.tipo} onChange={onChange} />
        
<Input
type="text"
id="historico"
label="Historico"
className="inputIncNome"
name="historico"
value={prodespesasData.historico}
onChange={onChange}               
/>

<InputCheckbox label="LivroCaixa" name="livrocaixa" checked={prodespesasData.livrocaixa} onChange={onChange} />

                </div>               
            </form>
        </div>
        
    </>
     );
};
 