import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/Cruds/EditWindow";
import EMPClassRiscosInc from "../Inc/EMPClassRiscos";
import { IEMPClassRiscos } from "../../Interfaces/interface.EMPClassRiscos";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { EMPClassRiscosEmpty } from "@/app/GerAdv_TS/Models/EMPClassRiscos";
import { useWindow } from "@/app/hooks/useWindows";

interface EMPClassRiscosWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedEMPClassRiscos?: IEMPClassRiscos;
    onSuccess: () => void;
    onError: () => void;
}

const EMPClassRiscosWindow: React.FC<EMPClassRiscosWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedEMPClassRiscos,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();
    const dimensionsEmpty = useWindow();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/empclassriscos/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedEMPClassRiscos?.id ?? '0'}`);
        }

    }, [isMobile, router, selectedEMPClassRiscos]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? dimensionsEmpty}
                    newHeight={445}
                    newWidth={720}
                    id={(selectedEMPClassRiscos?.id ?? 0).toString()}
                >
                    <EMPClassRiscosInc
                        id={selectedEMPClassRiscos?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowEMPClassRiscos: React.FC<EMPClassRiscosWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <EMPClassRiscosWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedEMPClassRiscos={EMPClassRiscosEmpty()}>
        </EMPClassRiscosWindow>
    )
};

export default EMPClassRiscosWindow;