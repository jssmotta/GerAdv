// Forms.tsx.txt
"use client";
import { Button, Input } from '@progress/kendo-react-all';
import { IReuniao } from '@/app/GerAdv_TS/Reuniao/Interfaces/interface.Reuniao';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudFormsBase.css';
import '@/app/styles/CrudFormsMobile.css';
import '@/app/styles/Inputs.css';
import '@/app/styles/CrudForms.css'; // [ INDEX_SIZE ]
import ButtonsCrud from '@/app/components/Cruds/ButtonsCrud';
import { useIsMobile } from '@/app/context/MobileContext';

import ClientesComboBox from '@/app/GerAdv_TS/Clientes/ComboBox/Clientes';
import { ClientesApi } from '@/app/GerAdv_TS/Clientes/Apis/ApiClientes';
import InputName from '@/app/components/Inputs/InputName';
import InputInput from '@/app/components/Inputs/InputInput'
import InputCheckbox from '@/app/components/Inputs/InputCheckbox';

interface ReuniaoFormProps {
    reuniaoData: IReuniao;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const ReuniaoForm: React.FC<ReuniaoFormProps> = ({
    reuniaoData,
    onChange,
    onSubmit,
    onClose,
    onError,
  }) => {

  const router = useRouter(); 
  const isMobile = useIsMobile();
  const { systemContext } = useSystemContext();
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [nomeClientes, setNomeClientes] = useState('');
            const clientesApi = new ClientesApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
 
if (getParamFromUrl("clientes") > 0) {
  clientesApi
    .getById(getParamFromUrl("clientes"))
    .then((response) => {
      setNomeClientes(response.data.nome);
    })
    .catch((error) => {
      console.error(error);
    });

  if (reuniaoData.id === 0) {
    reuniaoData.cliente = getParamFromUrl("clientes");
  }
}
 const addValorCliente = (e: any) => {
                        if (e?.id>0)
                        reuniaoData.cliente = e.id;
                      };

    const onConfirm = (e: React.FormEvent) => {
    // Importante: prevenir comportamento padrão e propagação
    e.preventDefault();
    if (e.stopPropagation) e.stopPropagation();
    
    // Evitar múltiplos envios
    if (!isSubmitting) {
      setIsSubmitting(true);
      
      // Chamar onSubmit com o evento
      try {
        onSubmit(e);
      } catch (error) {
        console.error("Erro ao submeter formulário de Reuniao:", error);
        setIsSubmitting(false);
        if (onError) onError();
      }
    }
  };

  // Handler para submissão direta via ButtonsCrud
  const handleDirectSave = () => {
    if (!isSubmitting) {
      setIsSubmitting(true);
      
      try {
        // Criar um evento sintético básico para manter compatibilidade
        const syntheticEvent = {
          preventDefault: () => { },
          target: document.getElementById(`ReuniaoForm-${reuniaoData.id}`)
        } as unknown as React.FormEvent;
        
        // Chamar onSubmit diretamente
        onSubmit(syntheticEvent);
      } catch (error) {
        console.error("Erro ao salvar Reuniao diretamente:", error);
        setIsSubmitting(false);
        if (onError) onError();
      }
    }
  };

  return (
  <>
  
        <div className={isMobile ? 'form-container-Reuniao' : 'form-container form-container-Reuniao'}>
       
            <form className='formInputCadInc' id={`ReuniaoForm-${reuniaoData.id}`} onSubmit={onConfirm}>

                <ButtonsCrud data={reuniaoData} isSubmitting={isSubmitting} onClose={onClose} formId={`ReuniaoForm-${reuniaoData.id}`} preventPropagation={true} onSave={handleDirectSave} />

                <div className="grid-container">

            <ClientesComboBox
            name={'cliente'}
            value={reuniaoData.cliente}
            setValue={addValorCliente}
            label={'Clientes'}
            />

<InputInput
type="text"
id="idagenda"
label="IDAgenda"
className="inputIncNome"
name="idagenda"
value={reuniaoData.idagenda}
onChange={onChange}               
/>

<InputInput
type="text"
id="data"
label="Data"
className="inputIncNome"
name="data"
value={reuniaoData.data}
onChange={onChange}               
/>

<InputInput
type="text"
id="pauta"
label="Pauta"
className="inputIncNome"
name="pauta"
value={reuniaoData.pauta}
onChange={onChange}               
/>

<InputInput
type="text"
id="ata"
label="ATA"
className="inputIncNome"
name="ata"
value={reuniaoData.ata}
onChange={onChange}               
/>

<InputInput
type="text"
id="horainicial"
label="HoraInicial"
className="inputIncNome"
name="horainicial"
value={reuniaoData.horainicial}
onChange={onChange}               
/>

<InputInput
type="text"
id="horafinal"
label="HoraFinal"
className="inputIncNome"
name="horafinal"
value={reuniaoData.horafinal}
onChange={onChange}               
/>

<InputCheckbox label="Externa" name="externa" checked={reuniaoData.externa} onChange={onChange} />
        
<InputInput
type="text"
id="horasaida"
label="HoraSaida"
className="inputIncNome"
name="horasaida"
value={reuniaoData.horasaida}
onChange={onChange}               
/>

</div><div className="grid-container">        
<InputInput
type="text"
id="horaretorno"
label="HoraRetorno"
className="inputIncNome"
name="horaretorno"
value={reuniaoData.horaretorno}
onChange={onChange}               
/>

<InputInput
type="text"
id="principaisdecisoes"
label="PrincipaisDecisoes"
className="inputIncNome"
name="principaisdecisoes"
value={reuniaoData.principaisdecisoes}
onChange={onChange}               
/>

                </div>               
            </form>
        </div>
        <div className="form-spacer"></div>
        
    </>
     );
};
 