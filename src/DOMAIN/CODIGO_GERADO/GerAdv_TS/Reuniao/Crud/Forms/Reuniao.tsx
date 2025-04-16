"use client";
import { Button, Checkbox, Input } from '@progress/kendo-react-all';
import { IReuniao } from '../../Interfaces/interface.Reuniao';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudForms.css'; // [ INDEX_SIZE ]
import { useIsMobile } from '@/app/context/MobileContext';

import ClientesComboBox from '@/app/GerAdv_TS/Clientes/ComboBox/Clientes';
import { ClientesApi } from '@/app/GerAdv_TS/Clientes/Apis/ApiClientes';

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
    e.preventDefault();
    if (!isSubmitting) {
      setIsSubmitting(true);
      onSubmit(e);
    }
   };

  return (
  <>
  {nomeClientes && (<h2>{nomeClientes}</h2>)}

    <div className="form-container">
       
        <form onSubmit={onConfirm}>
         
         <div className="grid-container">

            <ClientesComboBox
            name={'cliente'}
            value={reuniaoData.cliente}
            setValue={addValorCliente}
            label={'Clientes'}
            />

<Input
type="text"
id="idagenda"
label="IDAgenda"
className="inputIncNome"
name="idagenda"
value={reuniaoData.idagenda}
onChange={onChange}               
/>

<Input
type="text"
id="data"
label="Data"
className="inputIncNome"
name="data"
value={reuniaoData.data}
onChange={onChange}               
/>

<Input
type="text"
id="pauta"
label="Pauta"
className="inputIncNome"
name="pauta"
value={reuniaoData.pauta}
onChange={onChange}               
/>

<Input
type="text"
id="ata"
label="ATA"
className="inputIncNome"
name="ata"
value={reuniaoData.ata}
onChange={onChange}               
/>

<Input
type="text"
id="horainicial"
label="HoraInicial"
className="inputIncNome"
name="horainicial"
value={reuniaoData.horainicial}
onChange={onChange}               
/>

<Input
type="text"
id="horafinal"
label="HoraFinal"
className="inputIncNome"
name="horafinal"
value={reuniaoData.horafinal}
onChange={onChange}               
/>

<Checkbox label="Externa" name="externa" checked={reuniaoData.externa} onChange={onChange} />
        
<Input
type="text"
id="horasaida"
label="HoraSaida"
className="inputIncNome"
name="horasaida"
value={reuniaoData.horasaida}
onChange={onChange}               
/>

</div><div className="grid-container">        
<Input
type="text"
id="horaretorno"
label="HoraRetorno"
className="inputIncNome"
name="horaretorno"
value={reuniaoData.horaretorno}
onChange={onChange}               
/>

<Input
type="text"
id="principaisdecisoes"
label="PrincipaisDecisoes"
className="inputIncNome"
name="principaisdecisoes"
value={reuniaoData.principaisdecisoes}
onChange={onChange}               
/>

							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/reuniaopessoas${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?reuniao=${reuniaoData.id}`)}>Reuniao Pessoas</div>

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
 