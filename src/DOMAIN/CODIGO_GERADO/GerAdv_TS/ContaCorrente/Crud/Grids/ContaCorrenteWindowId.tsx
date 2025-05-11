// WindowId.tsx.txt
import React, { useEffect, useMemo } from "react";
import { useSystemContext } from "@/app/context/SystemContext";
import { IContaCorrente } from "../../Interfaces/interface.ContaCorrente";
import { ContaCorrenteService } from "../../Services/ContaCorrente.service";
import { ContaCorrenteApi } from "../../Apis/ApiContaCorrente";
import ContaCorrenteWindow from "./ContaCorrenteWindow";

interface ContaCorrenteWindowIdProps {
    isOpen: boolean; 
    onClose: () => void;    
    id?: number;
    onSuccess: () => void;
    onError: () => void;
}

const ContaCorrenteWindowId: React.FC<ContaCorrenteWindowIdProps> = ({
    isOpen,
    onClose,    
    id,
    onSuccess,
    onError,
}) => {

    const { systemContext } = useSystemContext(); 
    const contacorrenteService = useMemo(() => {
        return new ContaCorrenteService(
            new ContaCorrenteApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
        );
    }, [systemContext?.Uri, systemContext?.Token]);

    const [data, setData] = React.useState<IContaCorrente | null>(null);

    useEffect(() => {
        const fetchData = async () => {
            if (id) {
                 const response = await contacorrenteService.fetchContaCorrenteById(id??0);
                setData(response);
            }
        };
        fetchData();
    }, [isOpen, id]);
     
    return (
        <>
            {data && isOpen && (
                <ContaCorrenteWindow 
                    isOpen={isOpen}
                    onClose={onClose}                    
                    selectedContaCorrente={data} 
                    onSuccess={onSuccess} 
                    onError={onError} />
            )}
        </>
    );
};

export default ContaCorrenteWindowId;