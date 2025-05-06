// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IHonorariosDadosContrato } from '@/app/GerAdv_TS/HonorariosDadosContrato/Interfaces/interface.HonorariosDadosContrato';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudFormsBase.css';
import '@/app/styles/Inputs.css';
import '@/app/styles/CrudForms5.css'; // [ INDEX_SIZE ]
import ButtonsCrud from '@/app/components/Cruds/ButtonsCrud';
import { useIsMobile } from '@/app/context/MobileContext';

import ClientesComboBox from '@/app/GerAdv_TS/Clientes/ComboBox/Clientes';
import ProcessosComboBox from '@/app/GerAdv_TS/Processos/ComboBox/Processos';
import { ClientesApi } from '@/app/GerAdv_TS/Clientes/Apis/ApiClientes';
import { ProcessosApi } from '@/app/GerAdv_TS/Processos/Apis/ApiProcessos';
import InputName from '@/app/components/Inputs/InputName';
import InputCheckbox from '@/app/components/Inputs/InputCheckbox';

interface HonorariosDadosContratoFormProps {
    honorariosdadoscontratoData: IHonorariosDadosContrato;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const HonorariosDadosContratoForm: React.FC<HonorariosDadosContratoFormProps> = ({
    honorariosdadoscontratoData,
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

  if (honorariosdadoscontratoData.id === 0) {
    honorariosdadoscontratoData.cliente = getParamFromUrl("clientes");
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

  if (honorariosdadoscontratoData.id === 0) {
    honorariosdadoscontratoData.processo = getParamFromUrl("processos");
  }
}
 const addValorCliente = (e: any) => {
                        if (e?.id>0)
                        honorariosdadoscontratoData.cliente = e.id;
                      };
 const addValorProcesso = (e: any) => {
                        if (e?.id>0)
                        honorariosdadoscontratoData.processo = e.id;
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
      const formElement = document.getElementById('HonorariosDadosContratoForm');

      if (formElement) {
        const syntheticEvent = new Event('submit', { bubbles: true, cancelable: true });
        formElement.dispatchEvent(syntheticEvent);
      }
    }
  };

  return (
  <>
  
        <div className="form-container5">
       
            <form id={`HonorariosDadosContratoForm-${honorariosdadoscontratoData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={honorariosdadoscontratoData} isSubmitting={isSubmitting} onClose={onClose} formId={`HonorariosDadosContratoForm-${honorariosdadoscontratoData.id}`} />

                <div className="grid-container">

            <ClientesComboBox
            name={'cliente'}
            value={honorariosdadoscontratoData.cliente}
            setValue={addValorCliente}
            label={'Clientes'}
            />

<InputCheckbox label="Fixo" name="fixo" checked={honorariosdadoscontratoData.fixo} onChange={onChange} />
<InputCheckbox label="Variavel" name="variavel" checked={honorariosdadoscontratoData.variavel} onChange={onChange} />
        
<Input
type="text"
id="percsucesso"
label="PercSucesso"
className="inputIncNome"
name="percsucesso"
value={honorariosdadoscontratoData.percsucesso}
onChange={onChange}               
/>

            <ProcessosComboBox
            name={'processo'}
            value={honorariosdadoscontratoData.processo}
            setValue={addValorProcesso}
            label={'Processos'}
            />

<Input
type="text"
id="arquivocontrato"
label="ArquivoContrato"
className="inputIncNome"
name="arquivocontrato"
value={honorariosdadoscontratoData.arquivocontrato}
onChange={onChange}               
/>

<Input
type="text"
id="textocontrato"
label="TextoContrato"
className="inputIncNome"
name="textocontrato"
value={honorariosdadoscontratoData.textocontrato}
onChange={onChange}               
/>

<Input
type="text"
id="valorfixo"
label="ValorFixo"
className="inputIncNome"
name="valorfixo"
value={honorariosdadoscontratoData.valorfixo}
onChange={onChange}               
/>

<Input
type="text"
id="observacao"
label="Observacao"
className="inputIncNome"
name="observacao"
value={honorariosdadoscontratoData.observacao}
onChange={onChange}               
/>

</div><div className="grid-container">        
<Input
type="text"
id="datacontrato"
label="DataContrato"
className="inputIncNome"
name="datacontrato"
value={honorariosdadoscontratoData.datacontrato}
onChange={onChange}               
/>

                </div>               
            </form>
        </div>
        
    </>
     );
};
 