export interface entiteHiearchieDto {
    id: string;
    label: string;
    parentId: string | null;
    type: string;
    enfants: entiteHiearchieDto[];
}
