"use client";
import { Button, Checkbox, Input } from '@progress/kendo-react-all';
import { IOperador } from '../../Interfaces/interface.Operador';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudForms.css'; // [ INDEX_SIZE ]
import { useIsMobile } from '@/app/context/MobileContext';

interface OperadorFormProps {
    operadorData: IOperador;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const OperadorForm: React.FC<OperadorFormProps> = ({
    operadorData,
    onChange,
    onSubmit,
    onClose,
    onError,
  }) => {

  const router = useRouter(); 
  const { systemContext } = useSystemContext();
  const [isSubmitting, setIsSubmitting] = useState(false);
  
  const onConfirm = (e: React.FormEvent) => {
    e.preventDefault();
    if (!isSubmitting) {
      setIsSubmitting(true);
      onSubmit(e);
    }
   };

  return (
  <>
  
    <div className="form-container">
       
        <form onSubmit={onConfirm}>
         
         <div className="grid-container">

    <Input
            type="text"            
            id="nome"
            label="nome"
            className="inputIncNome"
            name="nome"
            value={operadorData.nome}
            onChange={onChange}
            required
          />

<Input
type="email"
id="email"
label="EMail"
className="inputIncNome"
name="email"
value={operadorData.email}
onChange={onChange}               
/>

<Input
type="text"
id="pasta"
label="Pasta"
className="inputIncNome"
name="pasta"
value={operadorData.pasta}
onChange={onChange}               
/>

<Checkbox label="Telefonista" name="telefonista" checked={operadorData.telefonista} onChange={onChange} />
<Checkbox label="Master" name="master" checked={operadorData.master} onChange={onChange} />
        
<Input
type="text"
id="nick"
label="Nick"
className="inputIncNome"
name="nick"
value={operadorData.nick}
onChange={onChange}               
/>

<Checkbox label="Excluido" name="excluido" checked={operadorData.excluido} onChange={onChange} />
<Checkbox label="Situacao" name="situacao" checked={operadorData.situacao} onChange={onChange} />
        
<Input
type="text"
id="minhadescricao"
label="MinhaDescricao"
className="inputIncNome"
name="minhadescricao"
value={operadorData.minhadescricao}
onChange={onChange}               
/>

<Input
type="email"
id="emailnet"
label="EMailNet"
className="inputIncNome"
name="emailnet"
value={operadorData.emailnet}
onChange={onChange}               
/>

</div><div className="grid-container"><Checkbox label="OnLine" name="online" checked={operadorData.online} onChange={onChange} />
<Checkbox label="SysOp" name="sysop" checked={operadorData.sysop} onChange={onChange} />
<Checkbox label="IsFinanceiro" name="isfinanceiro" checked={operadorData.isfinanceiro} onChange={onChange} />
<Checkbox label="Top" name="top" checked={operadorData.top} onChange={onChange} />
<Checkbox label="Sexo" name="sexo" checked={operadorData.sexo} onChange={onChange} />
<Checkbox label="Basico" name="basico" checked={operadorData.basico} onChange={onChange} />
<Checkbox label="Externo" name="externo" checked={operadorData.externo} onChange={onChange} />
        
<Input
autoComplete="off"
type="password"
id="senha256"
label="Senha256"
className="inputIncNome"
name="senha256"
value={operadorData.senha256}
onChange={onChange}               
/>

<Checkbox label="EMailConfirmado" name="emailconfirmado" checked={operadorData.emailconfirmado} onChange={onChange} />
        
<Input
type="text"
id="datalimitereset"
label="DataLimiteReset"
className="inputIncNome"
name="datalimitereset"
value={operadorData.datalimitereset}
onChange={onChange}               
/>

							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/agenda${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?operador=${operadorData.id}`)}>Agenda</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/agendafinanceiro${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?operador=${operadorData.id}`)}>Agenda Financeiro</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/alarmsms${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?operador=${operadorData.id}`)}>Alarm S M S</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/alertas${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?operador=${operadorData.id}`)}>Alertas</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/alertasenviados${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?operador=${operadorData.id}`)}>Alertas Enviados</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/contatocrm${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?operador=${operadorData.id}`)}>Contato C R M</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/contatocrmoperador${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?operador=${operadorData.id}`)}>Contato C R M Operador</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/diario2${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?operador=${operadorData.id}`)}>Diario2</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/gutatividades${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?operador=${operadorData.id}`)}>G U T Atividades</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/operadoremailpopup${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?operador=${operadorData.id}`)}>Operador E Mail Popup</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/operadorgrupo${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?operador=${operadorData.id}`)}>Operador Grupo</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/operadorgruposagenda${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?operador=${operadorData.id}`)}>Operador Grupos Agenda</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/operadorgruposagendaoperadores${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?operador=${operadorData.id}`)}>Operador Grupos Agenda Operadores</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/pontovirtual${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?operador=${operadorData.id}`)}>Ponto Virtual</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/pontovirtualacessos${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?operador=${operadorData.id}`)}>Ponto Virtual Acessos</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/processosparados${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?operador=${operadorData.id}`)}>Processos Parados</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/processoutputrequest${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?operador=${operadorData.id}`)}>Process Output Request</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/reuniaopessoas${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?operador=${operadorData.id}`)}>Reuniao Pessoas</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/smsalice${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?operador=${operadorData.id}`)}>S M S Alice</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/statusbiu${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?operador=${operadorData.id}`)}>Status Biu</div>

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
 