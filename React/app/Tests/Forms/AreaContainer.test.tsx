import React from 'react';
import { render } from '@testing-library/react';
import AreaIncContainer from '@/app/GerAdv_TS/Area/Components/AreaIncContainer';
// AreaIncContainer.test.tsx
// Mock do AreaInc
jest.mock('@/app/GerAdv_TS/Area/Crud/Inc/Area', () => (props: any) => (
<div data-testid='area-inc-mock' {...props} />
));
describe('AreaIncContainer', () => {
  it('deve renderizar AreaInc com as props corretas', () => {
    const mockNavigator = {} as any;
    const id = 123;
    const { getByTestId } = render(
    <AreaIncContainer id={id} navigator={mockNavigator} />
  );
  const areaInc = getByTestId('area-inc-mock');
  expect(areaInc).toBeInTheDocument();
  expect(areaInc.getAttribute('id')).toBe(id.toString());

});
});