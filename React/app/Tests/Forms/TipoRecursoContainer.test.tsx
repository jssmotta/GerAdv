import React from 'react';
import { render } from '@testing-library/react';
import TipoRecursoIncContainer from '@/app/GerAdv_TS/TipoRecurso/Components/TipoRecursoIncContainer';
// TipoRecursoIncContainer.test.tsx
// Mock do TipoRecursoInc
jest.mock('@/app/GerAdv_TS/TipoRecurso/Crud/Inc/TipoRecurso', () => (props: any) => (
<div data-testid='tiporecurso-inc-mock' {...props} />
));
describe('TipoRecursoIncContainer', () => {
  it('deve renderizar TipoRecursoInc com as props corretas', () => {
    const mockNavigator = {} as any;
    const id = 123;
    const { getByTestId } = render(
    <TipoRecursoIncContainer id={id} navigator={mockNavigator} />
  );
  const tiporecursoInc = getByTestId('tiporecurso-inc-mock');
  expect(tiporecursoInc).toBeInTheDocument();
  expect(tiporecursoInc.getAttribute('id')).toBe(id.toString());

});
});