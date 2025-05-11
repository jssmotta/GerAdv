// WindowId.tsx.txt
import React, { useEffect, useMemo } from "react";
import { useSystemContext } from "@/app/context/SystemContext";
import { IOperadores } from "../../Interfaces/interface.Operadores";
import { OperadoresService } from "../../Services/Operadores.service";
import { OperadoresApi } from "../../Apis/ApiOperadores";
import OperadoresWindow from "./OperadoresWindow";

interface OperadoresWindowIdProps {
    isOpen: boolean; 
    onClose: () => void;    
    id?: number;
    onSuccess: () => void;
    onError: () => void;
}

const OperadoresWindowId: React.FC<OperadoresWindowIdProps> = ({
    isOpen,
    onClose,    
    id,
    onSuccess,
    onError,
}) => {

    const { systemContext } = useSystemContext(); 
    const operadoresService = useMemo(() => {
        return new OperadoresService(
            new OperadoresApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
        );
    }, [systemContext?.Uri, systemContext?.Token]);

    const [data, setData] = React.useState<IOperadores | null>(null);

    useEffect(() => {
        const fetchData = async () => {
            if (id) {
                 const response = await operadoresService.fetchOperadoresById(id??0);
                setData(response);
            }
        };
        fetchData();
    }, [isOpen, id]);
     
    return (
        <>
            {data && isOpen && (
                <OperadoresWindow 
                    isOpen={isOpen}
                    onClose={onClose}                    
                    selectedOperadores={data} 
                    onSuccess={onSuccess} 
                    onError={onError} />
            )}
        </>
    );
};

export default OperadoresWindowId;