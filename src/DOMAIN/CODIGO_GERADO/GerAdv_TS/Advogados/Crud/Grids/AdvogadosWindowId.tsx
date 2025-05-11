// WindowId.tsx.txt
import React, { useEffect, useMemo } from "react";
import { useSystemContext } from "@/app/context/SystemContext";
import { IAdvogados } from "../../Interfaces/interface.Advogados";
import { AdvogadosService } from "../../Services/Advogados.service";
import { AdvogadosApi } from "../../Apis/ApiAdvogados";
import AdvogadosWindow from "./AdvogadosWindow";

interface AdvogadosWindowIdProps {
    isOpen: boolean; 
    onClose: () => void;    
    id?: number;
    onSuccess: () => void;
    onError: () => void;
}

const AdvogadosWindowId: React.FC<AdvogadosWindowIdProps> = ({
    isOpen,
    onClose,    
    id,
    onSuccess,
    onError,
}) => {

    const { systemContext } = useSystemContext(); 
    const advogadosService = useMemo(() => {
        return new AdvogadosService(
            new AdvogadosApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
        );
    }, [systemContext?.Uri, systemContext?.Token]);

    const [data, setData] = React.useState<IAdvogados | null>(null);

    useEffect(() => {
        const fetchData = async () => {
            if (id) {
                 const response = await advogadosService.fetchAdvogadosById(id??0);
                setData(response);
            }
        };
        fetchData();
    }, [isOpen, id]);
     
    return (
        <>
            {data && isOpen && (
                <AdvogadosWindow 
                    isOpen={isOpen}
                    onClose={onClose}                    
                    selectedAdvogados={data} 
                    onSuccess={onSuccess} 
                    onError={onError} />
            )}
        </>
    );
};

export default AdvogadosWindowId;