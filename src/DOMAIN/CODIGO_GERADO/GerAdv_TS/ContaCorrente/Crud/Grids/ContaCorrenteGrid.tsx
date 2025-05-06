//CrudGrid.tsx.txt
"use client";
import { AppGridToolbar } from "@/app/components/Cruds/GridToolbar";
import { useIsMobile } from "@/app/context/MobileContext";
import { useSystemContext } from "@/app/context/SystemContext";
import { ContaCorrenteEmpty } from "../../../Models/ContaCorrente";
import { useWindow } from "@/app/hooks/useWindows";
import { useRouter } from "next/navigation";
import { useEffect, useMemo, useState } from "react";
import { IContaCorrente } from "../../Interfaces/interface.ContaCorrente";
import { ContaCorrenteService } from "../../Services/ContaCorrente.service";
import { ContaCorrenteApi } from "../../Apis/ApiContaCorrente";
import { ContaCorrenteGridMobileComponent } from "../GridsMobile/ContaCorrente";
import { ContaCorrenteGridDesktopComponent } from "../GridsDesktop/ContaCorrente";
import { getParamFromUrl } from "@/app/tools/helpers";
import { FilterContaCorrente } from "../../Filters/ContaCorrente";
import { ConfirmationModal } from "@/app/components/Cruds/ConfirmationModal";
import ContaCorrenteWindow from "./ContaCorrenteWindow";

const ContaCorrenteGrid: React.FC = () => {
    const { systemContext } = useSystemContext();
    const [selectedId, setSelectedId] = useState<number | null>(null);
    const isMobile = useIsMobile();
    const router = useRouter();
    const dimensions = useWindow();
    
    const [contacorrente, setContaCorrente] = useState<IContaCorrente[]>([]);
    const [showInc, setShowInc] = useState(false);
    const [selectedContaCorrente, setSelectedContaCorrente] = useState<IContaCorrente>(ContaCorrenteEmpty());     

    const [isModalOpen, setIsModalOpen] = useState(false);
    const [deleteId, setDeleteId] = useState<number | null>(null);
    const dadoApi = new ContaCorrenteApi(systemContext?.Uri ?? '', systemContext?.Token ?? '');

    const [currFilter, setCurrFilter] = useState<FilterContaCorrente | undefined | null>(null);

    const contacorrenteService = useMemo(() => {
      return new ContaCorrenteService(
          new ContaCorrenteApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
      ); 
    }, [systemContext?.Uri, systemContext?.Token]);
  
    const fetchContaCorrente = async (filtro?: FilterContaCorrente | undefined | null) => {
      setCurrFilter(filtro);
      if (isMobile) {
        const data = await contacorrenteService.getAll(filtro ?? {} as FilterContaCorrente);
        setContaCorrente(data);
      }
      else {
        const data = await contacorrenteService.getAll(filtro ?? {} as FilterContaCorrente);
        setContaCorrente(data);
      }
    };
  
    useEffect(() => { //  Ref: FILTER_FETCH
      fetchContaCorrente(currFilter);
    }, [showInc]);
  
    const handleRowClick = (contacorrente: IContaCorrente) => {
      if (isMobile) {
        router.push(`/pages/contacorrente/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${contacorrente.id}`);
      } else {
        setSelectedContaCorrente(contacorrente);
        setShowInc(true);
      }
    };
  
    const handleAdd = () => {
      if (isMobile) {
        router.push(`/pages/contacorrente/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=0`);
        return;
      }
      setSelectedContaCorrente(ContaCorrenteEmpty());
      setShowInc(true);
    };
  
    const handleClose = () => {
      setShowInc(false);
    };
  
    const handleSuccess = () => {
      fetchContaCorrente(currFilter);
      setShowInc(false);
    };

    const handleError = () => {
      setShowInc(false);
    };
  
    const onDeleteClick = (e: any) => {
        const contacorrente = e.dataItem;		
        setDeleteId(contacorrente.id);
        setIsModalOpen(true);
    };
      
    const confirmDelete = async () => {
        if (deleteId !== null) {
            try {
                await dadoApi.delete(deleteId);			
                fetchContaCorrente(currFilter);
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
            
        {isMobile ?
           <ContaCorrenteGridMobileComponent data={contacorrente} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> :
           <ContaCorrenteGridDesktopComponent data={contacorrente} onRowClick={handleRowClick} onDeleteClick={onDeleteClick} setSelectedId={setSelectedId}  /> }       
     
        <ContaCorrenteWindow
          isOpen={showInc}
          onClose={handleClose}
          dimensions={dimensions} 
          onSuccess={handleSuccess}
          onError={handleError}
          selectedContaCorrente={selectedContaCorrente}>       
        </ContaCorrenteWindow>

        <ConfirmationModal 
          isOpen={isModalOpen}
          onConfirm={confirmDelete}
          onCancel={cancelDelete}
          message={`Deseja realmente excluir o registro?`} 
        />
      </>
    );
  };
  
  export default ContaCorrenteGrid;