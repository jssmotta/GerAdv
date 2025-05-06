//CrudGrid.tsx.txt
"use client";
import { AppGridToolbar } from "@/app/components/Cruds/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { BensClassificacaoEmpty } from "../../../Models/BensClassificacao";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import { IBensClassificacao } from "../../Interfaces/interface.BensClassificacao";
import { BensClassificacaoService } from "../../Services/BensClassificacao.service";
import { BensClassificacaoApi } from "../../Apis/ApiBensClassificacao";
import { BensClassificacaoGridMobileComponent } from "../GridsMobile/BensClassificacao";
import { BensClassificacaoGridDesktopComponent } from "../GridsDesktop/BensClassificacao";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterBensClassificacao } from "../../Filters/BensClassificacao";
import { ConfirmationModal } from "@/app/components/Cruds/ConfirmationModal";
import BensClassificacaoWindow from "./BensClassificacaoWindow";

const BensClassificacaoGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const [selectedId, setSelectedId] = useState<number | null>(null);
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [bensclassificacao, setBensClassificacao] = useState<IBensClassificacao[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedBensClassificacao, setSelectedBensClassificacao] = useState<IBensClassificacao>(BensClassificacaoEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new BensClassificacaoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterBensClassificacao | undefined | null>(null);

    const bensclassificacaoService = useMemo(() => {
      return new BensClassificacaoService(
          new BensClassificacaoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchBensClassificacao = async (filtro?: FilterBensClassificacao | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await bensclassificacaoService.getList(filtro ?? {} as FilterBensClassificacao);
        setBensClassificacao(data);
      }
      else {
        const data = await bensclassificacaoService.getAll(filtro ?? {} as FilterBensClassificacao);
        setBensClassificacao(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchBensClassificacao(currFilter);
    }, [showInc]);
  
    const handleRowClick = (bensclassificacao: IBensClassificacao) => {
      if (isMobile) {
        router.push(`/pages/bensclassificacao/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${bensclassificacao.id}`);
      } else {
        setSelectedBensClassificacao(bensclassificacao);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/bensclassificacao/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedBensClassificacao(BensClassificacaoEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchBensClassificacao(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const bensclassificacao = e.dataItem;		
        setDeleteId(bensclassificacao.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchBensClassificacao(currFilter);
            } catch {
            // falta uma mensagem de erro
            } finally {
            setDeleteId(null);
                setIsModalOpen(false);
            }
        }
    };
      
    const cancelDelete = () => {
        setDeleteId(null);
        setIsModalOpen(false);
    };

    return (
      <>
        <AppGridToolbar onAdd={handleAdd} />    

        {isMobile ?
           <BensClassificacaoGridMobileComponent data={bensclassificacao} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> :
           <BensClassificacaoGridDesktopComponent data={bensclassificacao} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> }       
     
        <BensClassificacaoWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedBensClassificacao={selectedBensClassificacao}>       
        </BensClassificacaoWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default BensClassificacaoGrid;