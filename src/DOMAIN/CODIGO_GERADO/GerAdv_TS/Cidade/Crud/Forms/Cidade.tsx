"use client";
import { Button, Checkbox, Input } from '@progress/kendo-react-all';
import { ICidade } from '../../Interfaces/interface.Cidade';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { useSystemContext } from '@/app/context/SystemContext';
import { getParamFromUrl } from '@/app/tools/helpers';
import '@/app/styles/CrudForms5.css'; // [ INDEX_SIZE ]
import { useIsMobile } from '@/app/context/MobileContext';

import UFComboBox from '@/app/GerAdv_TS/UF/ComboBox/UF';
import { UFApi } from '@/app/GerAdv_TS/UF/Apis/ApiUF';

interface CidadeFormProps {
    cidadeData: ICidade;
    onChange: (e: any) => void;
    onSubmit: (e: React.FormEvent) => void;
    onClose: () => void;
    onError?: () => void;
  }
  
  export const CidadeForm: React.FC<CidadeFormProps> = ({
    cidadeData,
    onChange,
    onSubmit,
    onClose,
    onError,
  }) => {

  const router = useRouter(); 
  const { systemContext } = useSystemContext();
  const [isSubmitting, setIsSubmitting] = useState(false);
  const [nomeUF, setNomeUF] = useState('');
            const ufApi = new UFApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');
 
if (getParamFromUrl("uf") > 0) {
  ufApi
    .getById(getParamFromUrl("uf"))
    .then((response) => {
      setNomeUF(response.data.d);
    })
    .catch((error) => {
      console.error(error);
    });

  if (cidadeData.id === 0) {
    cidadeData.uf = getParamFromUrl("uf");
  }
}
 const addValorUF = (e: any) => {
                        if (e?.id>0)
                        cidadeData.uf = e.id;
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
  {nomeUF && (<h2>{nomeUF}</h2>)}

    <div className="form-container">
       
        <form onSubmit={onConfirm}>
         
         <div className="grid-container">

    <Input
            type="text"            
            id="nome"
            label="nome"
            className="inputIncNome"
            name="nome"
            value={cidadeData.nome}
            onChange={onChange}
            required
          />

<Input
type="text"
id="ddd"
label="DDD"
className="inputIncNome"
name="ddd"
value={cidadeData.ddd}
onChange={onChange}               
/>

<Checkbox label="Top" name="top" checked={cidadeData.top} onChange={onChange} />
<Checkbox label="Comarca" name="comarca" checked={cidadeData.comarca} onChange={onChange} />
<Checkbox label="Capital" name="capital" checked={cidadeData.capital} onChange={onChange} />
 
            <UFComboBox
            name={'uf'}
            value={cidadeData.uf}
            setValue={addValorUF}
            label={'UF'}
            />

<Input
type="text"
id="sigla"
label="Sigla"
className="inputIncNome"
name="sigla"
value={cidadeData.sigla}
onChange={onChange}               
/>

							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/advogados${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?cidade=${cidadeData.id}`)}>Advogados</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/agenda${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?cidade=${cidadeData.id}`)}>Agenda</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/agendafinanceiro${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?cidade=${cidadeData.id}`)}>Agenda Financeiro</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/bensmateriais${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?cidade=${cidadeData.id}`)}>Bens Materiais</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/clientes${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?cidade=${cidadeData.id}`)}>Clientes</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/clientessocios${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?cidade=${cidadeData.id}`)}>Clientes Socios</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/colaboradores${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?cidade=${cidadeData.id}`)}>Colaboradores</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/divisaotribunal${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?cidade=${cidadeData.id}`)}>Divisao Tribunal</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/enderecos${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?cidade=${cidadeData.id}`)}>Endereços</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/enderecosistema${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?cidade=${cidadeData.id}`)}>Endereco Sistema</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/escritorios${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?cidade=${cidadeData.id}`)}>Escritorios</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/fornecedores${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?cidade=${cidadeData.id}`)}>Fornecedores</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/foro${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?cidade=${cidadeData.id}`)}>Foro</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/funcionarios${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?cidade=${cidadeData.id}`)}>Colaborador</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/oponentes${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?cidade=${cidadeData.id}`)}>Oponentes</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/oponentesreplegal${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?cidade=${cidadeData.id}`)}>Oponentes Rep Legal</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/outraspartescliente${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?cidade=${cidadeData.id}`)}>Outras Partes Cliente</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/poderjudiciarioassociado${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?cidade=${cidadeData.id}`)}>Poder Judiciario Associado</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/preclientes${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?cidade=${cidadeData.id}`)}>Pre Clientes</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/prepostos${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?cidade=${cidadeData.id}`)}>Prepostos</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/processos${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?cidade=${cidadeData.id}`)}>Processos</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/terceiros${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?cidade=${cidadeData.id}`)}>Terceiros</div>
							<div className='relacionamentosLinks' onClick={()=> router.push(`/pages/tribenderecos${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?cidade=${cidadeData.id}`)}>Trib Endereços</div>

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
 